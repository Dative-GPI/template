using System;

namespace XXXXX.Domain.Repositories.Commands
{
    public class UpdateRolePermissions
    {
        public Guid RoleId { get; set; }
        public Guid PermissionsId { get; set; }
    }
}