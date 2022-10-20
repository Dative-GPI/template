using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using AutoMapper;

using Bones.Flow;

using XXXXX.Domain.Models;
using XXXXX.Gateway.Core.Interfaces;
using XXXXX.Gateway.Core.ViewModels;

namespace XXXXX.Gateway.Core.Services
{
    public class ApplicationTranslationService : IApplicationTranslationService
    {
        private IQueryHandler<ApplicationTranslationsQuery, IEnumerable<ApplicationTranslation>> _applicationTranslationsQueryHandler;
        private IMapper _mapper;

        public ApplicationTranslationService(
            IQueryHandler<ApplicationTranslationsQuery, IEnumerable<ApplicationTranslation>> applicationTranslationsQueryHandler,
            IMapper mapper
        )
        {
            _applicationTranslationsQueryHandler = applicationTranslationsQueryHandler;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ApplicationTranslationViewModel>> GetMany(Guid applicationId, Guid actorId, string languageCode, Guid? organisationId)
        {
            var query = new ApplicationTranslationsQuery()
            {
                ApplicationId = applicationId,
                ActorId = actorId,
                LanguageCode = languageCode,
                OrganisationId = organisationId
            };

            var result = await _applicationTranslationsQueryHandler.HandleAsync(query);

            return _mapper.Map<IEnumerable<ApplicationTranslation>, IEnumerable<ApplicationTranslationViewModel>>(result);
        }
    }
}