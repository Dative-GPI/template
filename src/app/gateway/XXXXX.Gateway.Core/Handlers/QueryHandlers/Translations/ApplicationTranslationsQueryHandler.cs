using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Bones.Flow;
using XXXXX.Domain.Models;
using XXXXX.Gateway.Core.Abstractions;

namespace XXXXX.Gateway.Core.Handlers
{
    public class ApplicationTranslationsQueryHandler : IMiddleware<ApplicationTranslationsQuery, IEnumerable<ApplicationTranslation>>
    {
        private readonly IFoundationClientFactory _foundationClientFactory;
        private readonly ITranslationProvider _translationProvider;

        public ApplicationTranslationsQueryHandler(
            IFoundationClientFactory foundationClientFactory,
            ITranslationProvider translationProvider
        )
        {
            _foundationClientFactory = foundationClientFactory;
            _translationProvider = translationProvider;
        }

        public async Task<IEnumerable<ApplicationTranslation>> HandleAsync(ApplicationTranslationsQuery request, Func<Task<IEnumerable<ApplicationTranslation>>> next, CancellationToken cancellationToken)
        {
            if (request.OrganisationId.HasValue)
            {
                return await GetOrganisationTypeTranslations(request.ApplicationId, request.LanguageCode, request.OrganisationId.Value);
            }
            else
            {
                return await GetDefaultTranslations(request.ApplicationId, request.LanguageCode);
            }
        }

        private async Task<IEnumerable<ApplicationTranslation>> GetDefaultTranslations(Guid applicationId, string languageCode)
        {
            return await _translationProvider.GetDefaultTranslations(
                applicationId,
                languageCode
            );
        }

        private async Task<IEnumerable<ApplicationTranslation>> GetOrganisationTypeTranslations(Guid applicationId, string languageCode, Guid organisationId)
        {
            var foundationClient = await _foundationClientFactory.Create();
            var currentOrganisation = await foundationClient.Shell.Organisations.Get(organisationId);

            return await _translationProvider.GetTranslationsForOrganisationType(
                applicationId,
                languageCode,
                currentOrganisation.OrganisationTypeId
            );
        }
    }
}