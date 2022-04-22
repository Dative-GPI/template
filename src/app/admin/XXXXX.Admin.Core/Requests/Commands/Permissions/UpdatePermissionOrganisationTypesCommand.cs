using System;
using System.Collections.Generic;

using static XXXXX.Admin.Core.Authorizations;

namespace XXXXX.Admin.Core
{
    public class UpdatePermissionOrganisationTypesCommand : ICoreRequest
    {
        public IEnumerable<string> Authorizations => new[] { ADMIN_PERMISSIONORGANISATIONTYPE_UPDATE };
		public Guid ApplicationId { get; set; }
        public Guid ActorId { get; set; }

        public Guid OrganisationTypeId { get; set; }
        public IEnumerable<Guid> PermissionsIds { get; set; }
    }
}