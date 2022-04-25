using System;

using Bones.Repository.Interfaces;

namespace XXXXX.Context.Core.DTOs
{
    public class RolePermissionDTO : IEntity<Guid>, IDTO
    {
        public Guid Id { get; set; }
        public Guid RoleId { get; set; }
        public Guid PermissionId { get; set; }
        public PermissionDTO Permission { get; set; }
        public bool Disabled { get; set; }
    }
}