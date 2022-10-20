using System;
using System.Collections.Generic;

using Bones.Flow;

using XXXXX.Domain.Models;

namespace XXXXX.Admin.Core
{
    public class RoleAdminPermissionsQuery : ICoreRequest, IRequest<IEnumerable<PermissionAdminInfos>>
    {
        public IEnumerable<string> Authorizations => new string[] {};
		public Guid ApplicationId { get; set; }
        public Guid ActorId { get; set; }
        
        public Guid RoleAdminId { get; set; }
    }
}