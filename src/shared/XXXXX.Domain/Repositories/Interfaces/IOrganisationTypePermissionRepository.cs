using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using XXXXX.Domain.Models;
using XXXXX.Domain.Repositories.Commands;
using XXXXX.Domain.Repositories.Filters;

namespace XXXXX.Domain.Repositories.Interfaces
{
    public interface IOrganisationTypePermissionRepository
    {
        Task<IEnumerable<OrganisationTypePermission>> GetMany(OrganisationTypePermissionsFilter filter);
        Task CreateRange(IEnumerable<UpdateOrganisationTypePermissions> payload);
        Task RemoveRange(Guid[] permissionsIds);
    }
}