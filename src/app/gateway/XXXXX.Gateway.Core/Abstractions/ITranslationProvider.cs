using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using XXXXX.Domain.Models;

namespace XXXXX.Gateway.Core.Abstractions
{
    public interface ITranslationProvider
    {
        Task<IEnumerable<ApplicationTranslation>> GetTranslationsForOrganisationType(Guid applicationId, string languageCode, Guid organisationTypeId);
        Task<IEnumerable<ApplicationTranslation>> GetDefaultTranslations(Guid applicationId, string languageCode);
    }
}