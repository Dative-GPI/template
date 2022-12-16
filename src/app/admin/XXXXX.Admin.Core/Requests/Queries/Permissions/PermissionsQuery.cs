using System;
using System.Collections.Generic;

using Bones.Flow;
using Foundation.Clients;

using XXXXX.Domain.Models;

namespace XXXXX.Admin.Core
{
    public class PermissionsQuery : ICoreRequest, IRequest<IEnumerable<PermissionInfos>>
    {
        public IEnumerable<string> Authorizations => new[] { AdminAuthorizations.ADMIN_PERMISSION_INFOS };
		public Guid ApplicationId { get; set; }
        public Guid ActorId { get; set; }

        public string Search { get; set; }
        public Guid? OrganisationTypeId { get; set; }
        public Guid? RoleId { get; set; }
        public IEnumerable<Guid> PermissionIds { get; set; }
    }
}