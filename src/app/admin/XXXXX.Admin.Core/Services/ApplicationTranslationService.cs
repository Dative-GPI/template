using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using AutoMapper;

using Bones.Flow;

using XXXXX.Domain.Models;
using XXXXX.Admin.Core.Interfaces;
using XXXXX.Admin.Core.ViewModels;
using XXXXX.Admin.Core.Requests;
using System.Linq;

namespace XXXXX.Admin.Core.Services
{
    public class ApplicationTranslationService : IApplicationTranslationService
    {
        private IQueryHandler<ApplicationTranslationsQuery, IEnumerable<ApplicationTranslation>> _applicationTranslationsQueryHandler;
        private ICommandHandler<UpdateApplicationTranslationCommand> _updateApplicationTranslationsCommandHandler;
        private IMapper _mapper;

        public ApplicationTranslationService(
            IQueryHandler<ApplicationTranslationsQuery, IEnumerable<ApplicationTranslation>> applicationTranslationsQueryHandler,
            ICommandHandler<UpdateApplicationTranslationCommand> updateApplicationTranslationsCommandHandler,
            IMapper mapper
        )
        {
            _applicationTranslationsQueryHandler = applicationTranslationsQueryHandler;
            _updateApplicationTranslationsCommandHandler = updateApplicationTranslationsCommandHandler;
            _mapper = mapper;
        }

        public async Task UpdateRange(RequestHeaders headers, IEnumerable<UpdateApplicationTranslationViewModel> payload)
        {
            var command = new UpdateApplicationTranslationCommand()
            {
                ActorId = headers.ActorId,
                ApplicationId = headers.ApplicationId,
                ApplicationTranslations = payload.Select(tr => new UpdateApplicationTranslation()
                {
                    LanguageCode = tr.LanguageCode,
                    OrganisationTypeId = tr.OrganisationTypeId,
                    TranslationCode = tr.TranslationCode,
                    Value = tr.Value
                }).ToList()
            };

            await _updateApplicationTranslationsCommandHandler.HandleAsync(command);
        }

        public async Task<IEnumerable<ApplicationTranslationViewModel>> GetMany(RequestHeaders headers)
        {
            var query = new ApplicationTranslationsQuery()
            {
                ActorId = headers.ActorId,
                ApplicationId = headers.ApplicationId
            };

            var results = await _applicationTranslationsQueryHandler.HandleAsync(query);

            return _mapper.Map<IEnumerable<ApplicationTranslation>, IEnumerable<ApplicationTranslationViewModel>>(results);
        }
    }
}