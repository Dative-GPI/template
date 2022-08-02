using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using XXXXX.Admin.Core.Interfaces;
using XXXXX.Admin.Core;
using XXXXX.Admin.Core.ViewModels;

namespace XXXXX.Admin.API.Controllers
{
    [Route("api/admin/routes")]
    public class RoutesController : AppController
    {
        private IRouteService _routeService;

        public RoutesController(IRouteService routeService)
        {
            _routeService = routeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMany([FromQuery] RoutesFilterViewModel filter){
            // var routes = await _routeService.GetMany(GetAppId(), GetActorId(), filter);

            var routes = new RouteInfosViewModel[] {
                new RouteInfosViewModel()
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
                new RouteInfosViewModel()
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
                new RouteInfosViewModel()
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
                new RouteInfosViewModel()
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

            return Ok(routes);
        }
    }
}
