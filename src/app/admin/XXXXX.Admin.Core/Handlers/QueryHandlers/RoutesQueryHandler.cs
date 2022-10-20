using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Bones.Flow;

using XXXXX.Domain.Models;
using XXXXX.Domain.Repositories.Filters;
using XXXXX.Domain.Repositories.Interfaces;
using XXXXX.Admin.Core;
using XXXXX.Admin.Core.Abstractions;

namespace XXXXX.Admin.Core.Handlers
{
    public class RoutesQueryHandler : IMiddleware<RoutesQuery, IEnumerable<RouteInfos>>
    {
        private IPermissionProvider _permissionProvider;

        public RoutesQueryHandler(
            IPermissionProvider permissionProvider    
        )
        {
            _permissionProvider = permissionProvider;
        }

        public async Task<IEnumerable<RouteInfos>> HandleAsync(RoutesQuery request, Func<Task<IEnumerable<RouteInfos>>> next, CancellationToken cancellationToken)
        {
            var permissions = await _permissionProvider.GetPermissions(request.ActorId);
            var routes = Routes.GetRoutes();

            var allowedRoutes = routes.Where(r => HasPermission(r, permissions)).ToList();
            return allowedRoutes;
        }

        private bool HasPermission(RouteInfos route, IEnumerable<string> permissions)
        {
            return !route.Authorizations.Except(permissions).Any();
        }
    }
}
