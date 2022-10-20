using System;
using System.Collections.Generic;

using Bones.Flow;
using Foundation.Clients;

using XXXXX.Domain.Models;

namespace XXXXX.Admin.Core
{
    public class OrganisationTypePermissionsQuery : ICoreRequest, IRequest<IEnumerable<PermissionInfos>>
    {
        public IEnumerable<string> Authorizations => new[] { AdminAuthorizations.ADMIN_PERMISSIONORGANISATIONTYPE_INFOS };
		public Guid ApplicationId { get; set; }
        public Guid ActorId { get; set; }
        
        public Guid OrganisationTypeId { get; set; }
    }
}