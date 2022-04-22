using System;
using System.Collections.Generic;

using Bones.Flow;

using XXXXX.Domain.Models;

using static XXXXX.Admin.Core.Authorizations;

namespace XXXXX.Admin.Core
{
    public class PermissionsCategoriesQuery : ICoreRequest, IRequest<IEnumerable<PermissionCategory>>
    {
        public IEnumerable<string> Authorizations => new[] { ADMIN_PERMISSION_CATEGORY };
        public Guid ApplicationId { get; set; }
        public Guid ActorId { get; set; }
    }
}