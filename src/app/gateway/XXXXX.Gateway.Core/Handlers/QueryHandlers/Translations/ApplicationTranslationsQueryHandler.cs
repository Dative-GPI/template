using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Bones.Flow;
using XXXXX.Domain.Abstractions;
using XXXXX.Domain.Models;
using XXXXX.Gateway.Core.Abstractions;

namespace XXXXX.Gateway.Core.Handlers
{
    public class ApplicationTranslationsQueryHandler : IMiddleware<ApplicationTranslationsQuery, IEnumerable<ApplicationTranslation>>
    {
        private readonly IFoundationClientFactory _foundationClientFactory;
        private readonly ITranslationsProvider _translationProvider;
        private readonly IRequestContextProvider _requestContextProvider;

        public ApplicationTranslationsQueryHandler(
            IFoundationClientFactory foundationClientFactory,
            ITranslationsProvider translationProvider,
            IRequestContextProvider requestContextProvider
        )
        {
            _foundationClientFactory = foundationClientFactory;
            _translationProvider = translationProvider;
            _requestContextProvider = requestContextProvider;
        }

        public async Task<IEnumerable<ApplicationTranslation>> HandleAsync(ApplicationTranslationsQuery request, Func<Task<IEnumerable<ApplicationTranslation>>> next, CancellationToken cancellationToken)
        {
            var context = _requestContextProvider.Context;
            return await _translationProvider.GetMany(
                context.ApplicationId,
                context.LanguageCode,
                context.OrganisationTypeId,
                context.Jwt
            );
        }
    }
}