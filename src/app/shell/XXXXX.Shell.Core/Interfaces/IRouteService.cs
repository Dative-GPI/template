using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using XXXXX.Shell.Core.ViewModels;

namespace XXXXX.Shell.Core.Interfaces
{
    public interface IRouteService
    {
        Task<IEnumerable<RouteInfosViewModel>> GetMany(RequestHeaders headers, Guid organisationId, RoutesFilterViewModel filter);
    }
}
