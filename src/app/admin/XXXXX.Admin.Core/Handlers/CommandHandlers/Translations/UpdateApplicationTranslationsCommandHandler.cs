using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Bones.Flow;

using XXXXX.Admin.Core.Requests;
using XXXXX.Domain.Repositories.Commands;
using XXXXX.Domain.Repositories.Filters;
using XXXXX.Domain.Repositories.Interfaces;

namespace XXXXX.Admin.Core.Handlers
{
    public class UpdateApplicationTranslationsCommandHandler : IMiddleware<UpdateApplicationTranslationCommand>
    {
        private ITranslationRepository _translationRepository;
        private IApplicationTranslationRepository _applicationTranslationRepository;

        public UpdateApplicationTranslationsCommandHandler(
            ITranslationRepository translationRepository,
            IApplicationTranslationRepository applicationTranslationRepository)
        {
            _translationRepository = translationRepository;
            _applicationTranslationRepository = applicationTranslationRepository;
        }

        public async Task HandleAsync(UpdateApplicationTranslationCommand request, Func<Task> next, CancellationToken cancellationToken)
        {
            var translations = await _translationRepository.GetMany();

            var formerTranslations = await _applicationTranslationRepository.GetMany(new ApplicationTranslationFilter()
            {
                ApplicationId = request.ApplicationId
            });

            await _applicationTranslationRepository.RemoveRange(formerTranslations.Select(t => t.Id));

            await _applicationTranslationRepository.CreateRange(
                request.ApplicationTranslations.Join(
                    translations, 
                    t => t.TranslationCode, 
                    t => t.Code, 
                    (req, tr) => new CreateApplicationTranslation()
                    {
                        ApplicationId = request.ApplicationId,
                        LanguageCode = req.LanguageCode,
                        OrganisationTypeId = req.OrganisationTypeId,
                        TranslationId = tr.Id,
                        Value = req.Value
                    }
                )
            );
        }
    }
}