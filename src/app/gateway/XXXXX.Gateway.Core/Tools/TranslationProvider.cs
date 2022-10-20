using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

using XXXXX.Domain.Models;
using XXXXX.Domain.Repositories.Filters;
using XXXXX.Domain.Repositories.Interfaces;

using XXXXX.Gateway.Core.Abstractions;

namespace XXXXX.Gateway.Core.Tools
{
    public class TranslationProvider : ITranslationProvider
    {
        private readonly ITranslationRepository _translationRepository;
        private readonly IApplicationTranslationRepository _applicationTranslationRepository;
        private readonly IFoundationClientFactory _foundationClientFactory;

        public TranslationProvider(
            ITranslationRepository translationRepository,
            IApplicationTranslationRepository applicationTranslationRepository,
            IFoundationClientFactory foundationClientFactory
        )
        {
            _translationRepository = translationRepository;
            _applicationTranslationRepository = applicationTranslationRepository;
            _foundationClientFactory = foundationClientFactory;
        }


        public async Task<IEnumerable<ApplicationTranslation>> GetTranslationsForOrganisationType(Guid applicationId, string languageCode, Guid organisationTypeId)
        {
            var translations = await _translationRepository.GetMany();

            var allTranslations = await FetchOrganisationTypeAndDefaultTranslations(applicationId, languageCode, organisationTypeId);
            var foundationTranslation = await FetchFoundationTranslations(languageCode);

            var specificTranslations = SelectMostSpecificTranslations(translations, allTranslations, foundationTranslation);
            return specificTranslations;
        }

        public async Task<IEnumerable<ApplicationTranslation>> GetDefaultTranslations(Guid applicationId, string languageCode)
        {
            var translations = await _translationRepository.GetMany();

            var allTranslations = await FetchDefaultTranslations(applicationId, languageCode);
            var foundationTranslation = await FetchFoundationTranslations(languageCode);

            var specificTranslations = SelectMostSpecificTranslations(translations, allTranslations, foundationTranslation);
            return specificTranslations;
        }

        private async Task<IEnumerable<ApplicationTranslation>> FetchOrganisationTypeAndDefaultTranslations(
            Guid applicationId, string languageCode, Guid organisationTypeId
        )
        {
            var filter = new ApplicationTranslationFilter()
            {
                ApplicationId = applicationId,
                LanguageCode = languageCode,
                OrganisationTypeIds = new Guid?[] { null, organisationTypeId }
            };

            var allTranslations = await _applicationTranslationRepository.GetMany(filter);
            return allTranslations;
        }

        private async Task<IEnumerable<ApplicationTranslation>> FetchDefaultTranslations(
            Guid applicationId, string languageCode
        )
        {
            var filter = new ApplicationTranslationFilter()
            {
                ApplicationId = applicationId,
                LanguageCode = languageCode,
                OrganisationTypeIds = new Guid?[] { null }
            };

            var allTranslations = await _applicationTranslationRepository.GetMany(filter);
            return allTranslations;
        }

        private async Task<IEnumerable<ApplicationTranslation>> FetchFoundationTranslations(string languageCode)
        {
            try
            {
                var client = await _foundationClientFactory.Create();
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
                    else
                    {
                        return fTrs.FirstOrDefault();
                    }
                }
            );

            var specificTranslations = withFoundationTranslations.Where(t => t != default);
            return specificTranslations;
        }
    }
}