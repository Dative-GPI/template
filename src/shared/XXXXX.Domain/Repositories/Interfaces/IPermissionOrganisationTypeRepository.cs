using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using XXXXX.Domain.Models;
using XXXXX.Domain.Repositories.Commands;
using XXXXX.Domain.Repositories.Filters;

namespace XXXXX.Domain.Repositories.Interfaces
{
    public interface IPermissionOrganisationTypeRepository
    {
        Task<IEnumerable<PermissionOrganisationType>> GetMany(PermissionOrganisationTypesFilter filter);
        Task CreateRange(IEnumerable<CreatePermissionOrganisationTypes> payload);
        Task RemoveRange(Guid[] permissionsIds);
    }
}