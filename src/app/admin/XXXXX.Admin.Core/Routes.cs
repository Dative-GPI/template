using System.Collections.Generic;

using XXXXX.Domain.Models;

namespace XXXXX.Admin.Core
{
    public static class Routes
    {
        private static readonly RouteInfos[] ROUTES = new RouteInfos[] {
            new RouteInfos()
            {
                Authorizations = new string[] {},
                Path = "/organisation-types/:organisationTypeId/permissions",
                Name = "apps.organisation-type-permissions",
                DrawerCategory = "Extension",
                DrawerIcon = "supervised_user_circle",
                DrawerLabel = "Organisation Type permissions",
                Exact = true,
                Id = System.Guid.NewGuid(),
                ShowOnDrawer = false,
                Uri = "https://extension-admin.localhost"
            },
            new RouteInfos()
            {
                Authorizations = new string[] {},
                Path = "/organisation-types/:organisationTypeId/roles/:roleId/permissions",
                Name = "apps.role-permissions",
                DrawerCategory = "Extension",
                DrawerIcon = "supervised_user_circle",
                DrawerLabel = "Role permissions",
                Exact = true,
                Id = System.Guid.NewGuid(),
                ShowOnDrawer = false,
                Uri = "https://extension-admin.localhost"
            },



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