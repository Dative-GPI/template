using System;
using System.Collections.Generic;

using Bones.Flow;

using Foundation.Clients;
using XXXXX.Domain.Models;

namespace XXXXX.Shell.Core
{
    public class OrganisationPermissionsQuery : ICoreRequest, IRequest<IEnumerable<PermissionInfos>>
    {
        public IEnumerable<string> Authorizations => new[] { ShellAuthorizations.APP_PERMISSIONORGANISATIONTYPE_INFOS };
		public Guid ApplicationId { get; set; }
        public Guid ActorId { get; set; }
        
        public Guid OrganisationId { get; set; }
    }
}