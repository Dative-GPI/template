using System;
using System.Collections.Generic;

using Bones.Flow;

using Foundation.Clients;
using XXXXX.Domain.Models;

namespace XXXXX.Shell.Core
{
    public class RolePermissionsQuery : ICoreRequest, IRequest<IEnumerable<PermissionInfos>>
    {
        public IEnumerable<string> Authorizations => new[] { ShellAuthorizations.APP_PERMISSIONROLE_INFOS };
		public Guid ApplicationId { get; set; }
        public Guid ActorId { get; set; }
        public Guid OrganisationId { get; set; }
        
        public Guid RoleId { get; set; }
    }
}