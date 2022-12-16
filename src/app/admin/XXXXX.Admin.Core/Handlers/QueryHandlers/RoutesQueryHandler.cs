using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Bones.Flow;

using XXXXX.Domain.Models;
using XXXXX.Admin.Core.Abstractions;
using XXXXX.Domain.Abstractions;
using XXXXX.Admin.Core.Models;

namespace XXXXX.Admin.Core.Handlers
{
    public class RoutesQueryHandler : IMiddleware<RoutesQuery, IEnumerable<RouteInfos>>
    {
        private readonly IPermissionProvider _permissionProvider;
        private readonly ITranslationsProvider _translationsProvider;
        private readonly IRequestContextProvider _requestContextProvider;

        public RoutesQueryHandler(
            IPermissionProvider permissionProvider ,
            ITranslationsProvider translationsProvider,
            IRequestContextProvider requestContextProvider   
        )
        {
            _permissionProvider = permissionProvider;
            _translationsProvider = translationsProvider;
            _requestContextProvider = requestContextProvider;
        }

        public async Task<IEnumerable<RouteInfos>> HandleAsync(RoutesQuery request, Func<Task<IEnumerable<RouteInfos>>> next, CancellationToken cancellationToken)
        {
            var permissions = await _permissionProvider.GetPermissions(request.ActorId);
            var routes = Routes.GetRoutes();

            var allowedRoutes = routes.Where(r => HasPermissions(r, permissions)).ToList();
            var translatedAllowedRoutes = await TranslateRoutesAsync(allowedRoutes);
            return translatedAllowedRoutes;
        }

        private bool HasPermissions(RouteDefinition route, IEnumerable<string> permissions)
        {
            return !route.Authorizations.Except(permissions).Any();
        }

        private async Task<IEnumerable<RouteInfos>> TranslateRoutesAsync(IEnumerable<RouteDefinition> routes)
        {
            var context = _requestContextProvider.Context;
            
            var translations = await _translationsProvider.GetMany(
                context.ApplicationId,
                context.LanguageCode,
                null,
                context.Jwt
            );

            return routes.GroupJoin(
                    translations,
                    r => r.DrawerCategoryCode,
                    t => t.TranslationCode,
                    (r, t) => new
                    {
                        Route = r,
                        Category = t.FirstOrDefault()?.Value ?? r.DrawerCategoryLabelDefault
                    }
                )
                .GroupJoin(
                    translations,
                    rc => rc.Route.DrawerLabelCode,
                    t => t.TranslationCode,
                    (rc, t) => new RouteInfos()
                    {
                        DrawerCategory = rc.Category,
                        DrawerIcon = rc.Route.DrawerIcon,
                        DrawerLabel = t.FirstOrDefault()?.Value ?? rc.Route.DrawerLabelDefault,
                        Exact = rc.Route.Exact,
                        Name = rc.Route.Name,
                        Path = rc.Route.Path,
                        ShowOnDrawer = rc.Route.ShowOnDrawer
                    }
                )
                .ToList();
        }
    }
}
