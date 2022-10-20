using System;
using System.Collections.Generic;

using Bones.Flow;
using Foundation.Clients;

using XXXXX.Domain.Models;

namespace XXXXX.Admin.Core
{
    public class PermissionCategoriesQuery : ICoreRequest, IRequest<IEnumerable<PermissionCategory>>
    {
        public IEnumerable<string> Authorizations => new[] { AdminAuthorizations.ADMIN_PERMISSION_CATEGORY };
        public Guid ApplicationId { get; set; }
        public Guid ActorId { get; set; }
    }
}