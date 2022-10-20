using System;
using System.Collections.Generic;

using Bones.Flow;

using XXXXX.Domain.Models;

namespace XXXXX.Admin.Core
{
    public class PermissionAdminCategoriesQuery : ICoreRequest, IRequest<IEnumerable<PermissionAdminCategory>>
    {
        public IEnumerable<string> Authorizations => new string[] {}; // Empty for now, so you can set your permissions
        public Guid ApplicationId { get; set; }
        public Guid ActorId { get; set; }
    }
}