using System.Collections.Generic;
using XXXXX.Admin.Core.Models;
using XXXXX.Domain.Models;

namespace XXXXX.Admin.Core
{
    public static class Routes
    {
        private static readonly RouteDefinition[] ROUTES = new RouteDefinition[] {
            new RouteDefinition()
            {
                Authorizations = new string[] {},
                Path = "/organisation-types/:organisationTypeId/permissions",
                Name = "apps.organisation-type-permissions",
                DrawerCategoryLabelDefault = null,
                DrawerCategoryCode = null,
                DrawerIcon = null,
                DrawerLabelDefault = null,
                Exact = true,
                ShowOnDrawer = false
            },
            new RouteDefinition()
            {
                Authorizations = new string[] {},
                Path = "/organisation-types/:organisationTypeId/roles/:roleId/permissions",
                Name = "apps.role-permissions",
                DrawerCategoryLabelDefault = null,
                DrawerCategoryCode = null,
                DrawerIcon = null,
                DrawerLabelDefault = null,
                DrawerLabelCode = null,
                Exact = true,
                ShowOnDrawer = false
            },



            new RouteDefinition()
            {
                Authorizations = new string[] {},
                Path = "/XXXXX/examples",
                Name = "apps.example",
                DrawerCategoryLabelDefault = "XXXXX",
                DrawerCategoryCode = "drawer.examples.category",
                DrawerIcon = "supervised_user_circle",
                DrawerLabelDefault = "Example",
                DrawerLabelCode = "drawer.examples.title",
                Exact = true,
                ShowOnDrawer = true
            },
            new RouteDefinition()
            {
                Authorizations = new string[] {},
                Path = "/XXXXX/examples/drawer",
                Name = "apps.example.drawer",
                DrawerCategoryLabelDefault = null,
                DrawerCategoryCode = null,
                DrawerIcon = null,
                DrawerLabelDefault = null,
                DrawerLabelCode = null,
                Exact = false,
                ShowOnDrawer = false
            },
        };


        public static IEnumerable<RouteDefinition> GetRoutes()
        {
            return ROUTES;
        }
    }
}