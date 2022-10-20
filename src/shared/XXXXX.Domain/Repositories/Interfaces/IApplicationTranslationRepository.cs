using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Bones.Repository.Interfaces;

using XXXXX.Domain.Models;
using XXXXX.Domain.Repositories.Commands;
using XXXXX.Domain.Repositories.Filters;

namespace XXXXX.Domain.Repositories.Interfaces
{
    public interface IApplicationTranslationRepository
    {
        Task<ApplicationTranslation> Get(Guid translationId);
        Task<IEnumerable<ApplicationTranslation>> GetMany(ApplicationTranslationFilter filter);
        Task CreateRange(IEnumerable<CreateApplicationTranslation> payload);
        Task RemoveRange(IEnumerable<Guid> translationIds);
    }
}