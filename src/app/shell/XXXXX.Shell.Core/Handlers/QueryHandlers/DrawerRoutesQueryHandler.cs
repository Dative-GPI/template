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
    public class DrawerRoutesQueryHandler : IMiddleware<DrawerRoutesQuery, IEnumerable<DrawerRouteInfos>>
    {
        private IDrawerRouteRepository _routeRepository;

        public DrawerRoutesQueryHandler(IDrawerRouteRepository routeRepository)
        {
            _routeRepository = routeRepository;
        }

        public async Task<IEnumerable<DrawerRouteInfos>> HandleAsync(DrawerRoutesQuery request, Func<Task<IEnumerable<DrawerRouteInfos>>> next, CancellationToken cancellationToken)
        {
            var DrawerRouteFilter = new DrawerRoutesFilter()
            {
                Search = request.Search
            };

            return await _routeRepository.GetMany(DrawerRouteFilter);
        }
    }
}
