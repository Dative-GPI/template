using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using AutoMapper;

using Bones.Flow;

using XXXXX.Domain.Models;
using XXXXX.Admin.Core.Interfaces;
using XXXXX.Admin.Core.ViewModels;
using XXXXX.Admin.Core.Requests;

namespace XXXXX.Admin.Core.Services
{
    public class TranslationService : ITranslationService
    {
        private IQueryHandler<TranslationsQuery, IEnumerable<Translation>> _translationsQueryHandler;
        private IMapper _mapper;

        public TranslationService(
            IQueryHandler<TranslationsQuery, IEnumerable<Translation>> translationsQueryHandler,
            IMapper mapper
        )
        {
            _translationsQueryHandler = translationsQueryHandler;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TranslationViewModel>> GetMany(RequestHeaders headers)
        {
            var query = new TranslationsQuery()
            {
                ApplicationId = headers.ApplicationId,
                ActorId = headers.ActorId
            };

            var result = await _translationsQueryHandler.HandleAsync(query);

            return _mapper.Map<IEnumerable<Translation>, IEnumerable<TranslationViewModel>>(result);
        }
    }
}