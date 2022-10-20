using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using XXXXX.Gateway.Core.ViewModels;

namespace XXXXX.Gateway.Core.Interfaces
{
    public interface IApplicationTranslationService
    {
        Task<IEnumerable<ApplicationTranslationViewModel>> GetMany(Guid applicationId, Guid actorId, string languageCode, Guid? organisationId);
    }
}