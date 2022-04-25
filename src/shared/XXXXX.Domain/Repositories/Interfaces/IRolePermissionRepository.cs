using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using XXXXX.Domain.Models;
using XXXXX.Domain.Repositories.Commands;
using XXXXX.Domain.Repositories.Filters;

namespace XXXXX.Domain.Repositories.Interfaces
{
    public interface IRolePermissionRepository
    {
        Task<IEnumerable<RolePermission>> GetMany(RolePermissionsFilter filter);
        Task CreateRange(IEnumerable<UpdateRolePermissions> payload);
        Task RemoveRange(Guid[] permissionsIds);
    }
}