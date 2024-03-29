using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

using XXXXX.Domain.Abstractions;
using XXXXX.Domain.Models;
using XXXXX.Domain.Repositories.Filters;
using XXXXX.Domain.Repositories.Interfaces;

namespace XXXXX.CrossCutting
{
    public class TranslationsProvider : ITranslationsProvider
    {
        private readonly ITranslationRepository _translationRepository;
        private readonly IApplicationTranslationRepository _applicationTranslationRepository;
        private readonly IFoundationClientFactory _foundationClientFactory;

        public TranslationsProvider(
            ITranslationRepository translationRepository,
            IApplicationTranslationRepository applicationTranslationRepository,
            IFoundationClientFactory foundationClientFactory
        )
        {
            _translationRepository = translationRepository;
            _applicationTranslationRepository = applicationTranslationRepository;
            _foundationClientFactory = foundationClientFactory;
        }


        public async Task<IEnumerable<ApplicationTranslation>> GetMany(Guid applicationId, string languageCode, Guid? organisationTypeId, string jwt)
        {
            var defaultTranslations = await FetchDefaultTranslations();
            var allTranslations = await FetchApplicationTranslations(applicationId, languageCode, organisationTypeId);
            var foundationTranslation = await FetchFoundationTranslations(applicationId, languageCode, jwt);

            var specificTranslations = SelectMostSpecificTranslations(defaultTranslations, allTranslations, foundationTranslation);
            return specificTranslations;
        }


        private async Task<IEnumerable<Translation>> FetchDefaultTranslations()
        {
            var translations = await _translationRepository.GetMany();
            return translations;
        }


        private async Task<IEnumerable<ApplicationTranslation>> FetchApplicationTranslations(Guid applicationId, string languageCode, Guid? organisationTypeId)
        {
            var filter = new ApplicationTranslationFilter()
            {
                ApplicationId = applicationId,
                LanguageCode = languageCode,
                OrganisationTypeIds = (new Guid?[] { null, organisationTypeId }).Distinct()
            };

            var allTranslations = await _applicationTranslationRepository.GetMany(filter);
            return allTranslations;
        }

        private async Task<IEnumerable<ApplicationTranslation>> FetchFoundationTranslations(Guid applicationId, string languageCode, string jwt)
        {
            try
            {
                var client = await _foundationClientFactory.CreateAuthenticated(applicationId, languageCode, jwt);
                var foundationTranslations = await client.Gateway.Translations.GetMany(languageCode);

                return foundationTranslations.Select(tr => new ApplicationTranslation()
                {
                    TranslationCode = tr.Code,
                    Value = tr.Value
                });
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.Unauthorized)
            {
                return Enumerable.Empty<ApplicationTranslation>();
            }
        }

        private IEnumerable<ApplicationTranslation> SelectMostSpecificTranslations(
            IEnumerable<Translation> translations,
            IEnumerable<ApplicationTranslation> allTranslations,
            IEnumerable<ApplicationTranslation> foundationTranslations
        )
        {
            var translationsAndAppTranslations = translations.GroupJoin(
                allTranslations,
                tr => tr.Code,
                apptr => apptr.TranslationCode,
                (tr, appTrs) => (
                    Translation: tr,
                    ApplicationTranslation: appTrs.OrderByDescending(t => t.OrganisationTypeId).FirstOrDefault() // This will order alphabetically in a descending order with null last
                )
            );

            var withFoundationTranslations = translationsAndAppTranslations.GroupJoin(
                foundationTranslations,
                tr => tr.Translation.Code,
                fTr => fTr.TranslationCode,
                (tr, fTrs) =>
                {
                    if (tr.ApplicationTranslation != default)
                    {
                        return tr.ApplicationTranslation;
                    }
                    else if (fTrs.Any())
                    {
                        return fTrs.First();
                    }
                    else
                    {
                        return new ApplicationTranslation()
                        {
                            Id = tr.Translation.Id,
                            TranslationCode = tr.Translation.Code,
                            Value = tr.Translation.Value
                        };
                    }
                }
            );

            var specificTranslations = withFoundationTranslations.Where(t => t != default);
            return specificTranslations;
        }
    }
}