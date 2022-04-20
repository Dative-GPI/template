using System;
using System.Collections.Generic;

using Bones.Flow;

using XXXXX.Domain.Models;
using XXXXX.Admin.Core;
using static XXXXX.Admin.Core.Authorizations;

namespace XXXXX.Admin.Core
{
    public class RoutesQuery : ICoreRequest, IRequest<IEnumerable<RouteInfos>>
    {
        public IEnumerable<string> Authorizations => new[] { DRAWER_ROUTE_INFOS };
        public Guid ApplicationId { get; set; }
        public Guid ActorId { get; set; }
        public string Search { get; set; }
    }
}
