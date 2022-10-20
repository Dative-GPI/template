using System.Collections.Generic;

using XXXXX.Domain.Models;

namespace XXXXX.Admin.Core
{
    public static class Routes
    {
        private static readonly RouteInfos[] ROUTES = new RouteInfos[] {
            new RouteInfos()
            {
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
                Path = "/applications/exemple",
                Name = "apps.exemple",
                DrawerCategory = "Extension",
                DrawerIcon = "supervised_user_circle",
                DrawerLabel = "Exemple",
                Exact = true,
                Id = System.Guid.NewGuid(),
                ShowOnDrawer = true,
                Uri = "https://extension-admin.localhost"
            },
            new RouteInfos()
            {
                Path = "/applications/secret/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba",
                Name = "apps.secret",
                DrawerCategory = "Extension",
                DrawerIcon = "supervised_user_circle",
                DrawerLabel = "secret",
                Exact = true,
                Id = System.Guid.NewGuid(),
                ShowOnDrawer = true,
                Uri = "https://extension-admin.localhost"
            },
        };


        public static IEnumerable<RouteInfos> GetRoutes()
        {
            return ROUTES;
        }
    }
}