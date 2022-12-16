using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using XXXXX.Domain.Models;

namespace XXXXX.Domain.Abstractions
{
    public interface ITranslationsProvider
    {
        Task<IEnumerable<ApplicationTranslation>> GetMany(Guid applicationId, string languageCode, Guid? organisationTypeId, string jwt);
    }
}