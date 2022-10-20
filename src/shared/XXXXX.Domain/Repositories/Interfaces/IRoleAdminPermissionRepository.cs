using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using XXXXX.Domain.Models;
using XXXXX.Domain.Repositories.Commands;
using XXXXX.Domain.Repositories.Filters;

namespace XXXXX.Domain.Repositories.Interfaces
{
    public interface IRoleAdminPermissionRepository
    {
        Task<IEnumerable<RoleAdminPermission>> GetMany(RoleAdminPermissionsFilter filter);
        Task CreateRange(IEnumerable<UpdateRoleAdminPermissions> payload);
        Task RemoveRange(Guid[] permissionAdminIds);
    }
}