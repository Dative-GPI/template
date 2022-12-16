using System;

using Bones.Repository.Interfaces;

namespace XXXXX.Context.Core.DTOs
{
    public class RoleAdminPermissionDTO : IEntity<Guid>, IDTO
    {
        public Guid Id { get; set; }
        public Guid RoleAdminId { get; set; }
        public Guid PermissionAdminId { get; set; }
        public PermissionAdminDTO PermissionAdmin { get; set; }
        public bool Disabled { get; set; }
    }
}