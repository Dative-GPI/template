using System;

namespace XXXXX.Domain.Repositories.Commands
{
    public class UpdateRoleAdminPermissions
    {
        public Guid RoleAdminId { get; set; }
        public Guid PermissionAdminId { get; set; }
    }
}