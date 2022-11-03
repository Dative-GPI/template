using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using XXXXX.Domain.Models;

namespace XXXXX.Gateway.Core.Abstractions
{
    public interface ITranslationsProvider
    {
        Task<IEnumerable<ApplicationTranslation>> Get(Guid applicationId, string languageCode, Guid? organisationTypeId);
    }
}