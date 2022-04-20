using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using XXXXX.Shell.Core.ViewModels;

namespace XXXXX.shell.Core.Interfaces
{
    public interface IRouteService
    {
        Task<IEnumerable<RouteInfosViewModel>> GetMany(Guid appId, Guid actorId, RoutesFilterViewModel filter);
    }
}
