using System;
using System.Collections.Generic;

using Foundation.Clients;
using static XXXXX.Shell.Core.Authorizations;

namespace XXXXX.Shell.Core
{
    public class UpdateRolePermissionsCommand : ICoreRequest
    {
        public IEnumerable<string> Authorizations => new[] { ShellAuthorizations.APP_PERMISSIONROLE_UPDATE };
		public Guid ApplicationId { get; set; }
        public Guid ActorId { get; set; }
        public Guid OrganisationId { get; set; }

        public Guid RoleId { get; set; }
        public IEnumerable<Guid> PermissionsIds { get; set; }
    }
}