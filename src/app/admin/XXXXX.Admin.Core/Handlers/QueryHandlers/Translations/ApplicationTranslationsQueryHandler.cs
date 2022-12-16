using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Bones.Flow;

using XXXXX.Admin.Core.Abstractions;
using XXXXX.Admin.Core.Requests;
using XXXXX.Domain.Models;
using XXXXX.Domain.Repositories.Filters;
using XXXXX.Domain.Repositories.Interfaces;

namespace XXXXX.Admin.Core.Handlers
{
    public class ApplicationTranslationsQueryHandler: IMiddleware<ApplicationTranslationsQuery, IEnumerable<ApplicationTranslation>>
    {
        private readonly IApplicationTranslationRepository _applicationTranslationRepository;

        public ApplicationTranslationsQueryHandler(
            IApplicationTranslationRepository applicationTranslationRepository
        )
        {
            _applicationTranslationRepository = applicationTranslationRepository;    
        }

        public async Task<IEnumerable<ApplicationTranslation>> HandleAsync(ApplicationTranslationsQuery request, Func<Task<IEnumerable<ApplicationTranslation>>> next, CancellationToken cancellationToken)
        {
            var filter  = new ApplicationTranslationFilter() {
                ApplicationId = request.ApplicationId
            };
            return await _applicationTranslationRepository.GetMany(filter);
        }
    }
}