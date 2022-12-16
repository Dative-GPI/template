using System;
using System.Collections.Generic;

using static XXXXX.Admin.Core.Authorizations;

namespace XXXXX.Admin.Core
{
    public class UpdateRoleAdminPermissionsCommand : ICoreRequest
    {
        public IEnumerable<string> Authorizations => new string[] {};
		public Guid ApplicationId { get; set; }
        public Guid ActorId { get; set; }

        public Guid RoleAdminId { get; set; }
        public IEnumerable<Guid> PermissionAdminsIds { get; set; }
    }
}