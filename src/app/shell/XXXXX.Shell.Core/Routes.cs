using System.Collections.Generic;

using Foundation.Clients;
using XXXXX.Domain.Models;

namespace XXXXX.Shell.Core
{
    public static class Routes
    {
        private static readonly RouteInfos[] ROUTES = new RouteInfos[] {
            new RouteInfos()
            {
                Path = "/applications/exemples",
                Name = "apps.exemples",
                DrawerCategory = "Extension",
                DrawerIcon = "supervised_user_circle",
                DrawerLabel = "Exemple",
                Exact = true,
                Id = System.Guid.NewGuid(),
                ShowOnDrawer = true,
                Uri = "https://extension.localhost"
            },
            new RouteInfos()
            {
                Path = "/applications/exemples/drawer",
                Name = "apps.exemples.drawer",
                DrawerCategory = "Extension",
                DrawerIcon = "supervised_user_circle",
                DrawerLabel = "Exemple drawer",
                Exact = false,
                Id = System.Guid.NewGuid(),
                ShowOnDrawer = false,
                Uri = "https://extension.localhost"
            },
        };

        public static IEnumerable<RouteInfos> GetRoutes()
        {
            return ROUTES;
        }
    }
}