using System;
using System.Collections.Generic;

using Foundation.Clients;

using static XXXXX.Admin.Core.Authorizations;

namespace XXXXX.Admin.Core
{
    public class UpdateRolePermissionsCommand : ICoreRequest
    {
        public IEnumerable<string> Authorizations => new[] { AdminAuthorizations.ADMIN_ORGANISATION_TYPE_ROLE_UPDATE };
		public Guid ApplicationId { get; set; }
        public Guid ActorId { get; set; }

        public Guid RoleId { get; set; }
        public IEnumerable<Guid> PermissionsIds { get; set; }
    }
}