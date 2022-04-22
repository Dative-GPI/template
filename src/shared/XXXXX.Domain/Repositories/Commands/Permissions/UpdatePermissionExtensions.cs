using System;

namespace XXXXX.Domain.Repositories.Commands
{
    public class UpdatePermissionExtensions
    {
        public Guid ExtensionId { get; set; }
        public Guid[] PermissionsIds { get; set; }
    }
}