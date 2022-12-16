using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Bones.Flow;

using XXXXX.Admin.Core.Requests;
using XXXXX.Domain.Models;
using XXXXX.Domain.Repositories.Interfaces;

namespace XXXXX.Admin.Core.Handlers
{
    public class TranslationsQueryHandler: IMiddleware<TranslationsQuery, IEnumerable<Translation>>
    {
        private readonly ITranslationRepository _translationRepository;

        public TranslationsQueryHandler(
            ITranslationRepository translationRepository
        )
        {
            _translationRepository = translationRepository;    
        }

        public async Task<IEnumerable<Translation>> HandleAsync(TranslationsQuery request, Func<Task<IEnumerable<Translation>>> next, CancellationToken cancellationToken)
        {
            return await _translationRepository.GetMany();
        }
    }
}