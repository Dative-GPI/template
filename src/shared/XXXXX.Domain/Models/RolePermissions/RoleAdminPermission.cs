using System;

namespace XXXXX.Domain.Models
{
    public class RoleAdminPermission
    {
        public Guid Id { get; set; }
        public Guid PermissionAdminId { get; set; }
        public string PermissionAdminCode { get; set; }
    }
}