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
                Authorizations = new string[] {},
                Path = "/XXXXX/examples",
                Name = "apps.example",
                DrawerCategory = "Extension",
                DrawerIcon = "supervised_user_circle",
                DrawerLabel = "Example",
                Exact = true,
                Id = System.Guid.NewGuid(),
                ShowOnDrawer = true,
                Uri = "https://extension.localhost"
            },
            new RouteInfos()
            {
                Authorizations = new string[] {},
                Path = "/XXXXX/examples/drawer",
                Name = "apps.example.drawer",
                DrawerCategory = "Extension",
                DrawerIcon = "supervised_user_circle",
                DrawerLabel = "Example drawer",
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