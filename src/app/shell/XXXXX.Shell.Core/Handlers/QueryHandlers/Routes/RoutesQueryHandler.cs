using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Bones.Flow;

using XXXXX.Domain.Models;
using XXXXX.Domain.Repositories.Filters;
using XXXXX.Domain.Repositories.Interfaces;
using XXXXX.Shell.Core;
using XXXXX.Shell.Core.Abstractions;

namespace XXXXX.Shell.Core.Handlers
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
            var permissions = await _permissionProvider.GetPermissions(request.OrganisationId, request.ActorId);
            var routes = Routes.GetRoutes();

            var allowedRoutes = routes.Where(r => HasPermissions(r, permissions)).ToList();
            return allowedRoutes;
        }

        private bool HasPermissions(RouteInfos route, IEnumerable<string> grantedPermissions)
        {
            return !route.Authorizations.Except(grantedPermissions).Any();
        }
    }
}
