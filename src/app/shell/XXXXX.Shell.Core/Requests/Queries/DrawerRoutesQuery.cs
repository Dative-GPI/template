using System;
using System.Collections.Generic;

using Bones.Flow;

using XXXXX.Domain.Models;
using XXXXX.Shell.Core;
using static XXXXX.Shell.Core.Authorizations;

namespace XXXXX.Shell.Core
{
    public class DrawerRoutesQuery : ICoreRequest, IRequest<IEnumerable<DrawerRouteInfos>>
    {
        public IEnumerable<string> Authorizations => new[] { DRAWER_ROUTE_INFOS };
        public Guid ApplicationId { get; set; }
        public Guid ActorId { get; set; }
        public string Search { get; set; }
    }
}
