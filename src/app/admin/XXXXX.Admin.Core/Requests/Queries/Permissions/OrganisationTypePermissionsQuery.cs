using System;
using System.Collections.Generic;

using Bones.Flow;

using XXXXX.Domain.Models;

using static XXXXX.Admin.Core.Authorizations;

namespace XXXXX.Admin.Core
{
    public class OrganisationTypePermissionsQuery : ICoreRequest, IRequest<IEnumerable<PermissionInfos>>
    {
        public IEnumerable<string> Authorizations => new[] { ADMIN_ORGANISATION_TYPE_PERMISSION_INFOS };
		public Guid ApplicationId { get; set; }
        public Guid ActorId { get; set; }
        
        public Guid OrganisationTypeId { get; set; }
    }
}