using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Bones.Flow;

using XXXXX.Domain.Models;
using XXXXX.Domain.Repositories.Filters;
using XXXXX.Domain.Repositories.Interfaces;
using XXXXX.Shell.Core;

namespace XXXXX.Shell.Core.Handlers
{
    public class RoutesQueryHandler : IMiddleware<RoutesQuery, IEnumerable<RouteInfos>>
    {
        private IRouteRepository _routeRepository;

        public RoutesQueryHandler(IRouteRepository routeRepository)
        {
            _routeRepository = routeRepository;
        }

        public async Task<IEnumerable<RouteInfos>> HandleAsync(RoutesQuery request, Func<Task<IEnumerable<RouteInfos>>> next, CancellationToken cancellationToken)
        {
            var routeFilter = new DrawerRoutesFilter()
            {
                Search = request.Search
            };

            return await _routeRepository.GetMany(routeFilter);
        }
    }
}
