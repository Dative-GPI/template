using System;
using System.Collections.Generic;

using static XXXXX.Admin.Core.Authorizations;

namespace XXXXX.Admin.Core
{
    public class UpdateOrganisationTypePermissionsCommand : ICoreRequest
    {
        public IEnumerable<string> Authorizations => new[] { ADMIN_ORGANISATION_TYPE_PERMISSION_UPDATE };
		public Guid ApplicationId { get; set; }
        public Guid ActorId { get; set; }

        public Guid OrganisationTypeId { get; set; }
        public IEnumerable<Guid> PermissionsIds { get; set; }
    }
}