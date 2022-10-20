using System;
using System.Collections.Generic;

using Bones.Flow;

using XXXXX.Domain.Models;
using XXXXX.Shell.Core;

namespace XXXXX.Shell.Core
{
    public class RoutesQuery : ICoreRequest, IRequest<IEnumerable<RouteInfos>>
    {
        public IEnumerable<string> Authorizations => new string[] {};
        public Guid ApplicationId { get; set; }
        public Guid ActorId { get; set; }
        public Guid OrganisationId { get; set; }
        public string Search { get; set; }
    }
}
