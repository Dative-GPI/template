using System;
using System.Collections.Generic;

using static XXXXX.Admin.Core.Authorizations;

namespace XXXXX.Admin.Core
{
    public class UpdateRolePermissionsCommand : ICoreRequest
    {
        public IEnumerable<string> Authorizations => new[] { ADMIN_ROLE_PERMISSIONS_UPDATE };
		public Guid ApplicationId { get; set; }
        public Guid ActorId { get; set; }

        public Guid RoleId { get; set; }
        public IEnumerable<Guid> PermissionsIds { get; set; }
    }
}