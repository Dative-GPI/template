using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using XXXXX.Shell.Core;
using XXXXX.Shell.Core.ViewModels;
using XXXXX.shell.Core.Interfaces;

namespace XXXXX.Shell.API.Controllers
{
    [Route("api/routes")]
    public class RoutesController : AppController
    {
        private IRouteService _routeService;

        public RoutesController(IRouteService routeService)
        {
            _routeService = routeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMany([FromQuery] RoutesFilterViewModel filter)
        {
            // var routes = await _routeService.GetMany(GetAppId(), GetActorId(), filter);

            var routes = new RouteInfosViewModel[] {
                new RouteInfosViewModel()
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
                new RouteInfosViewModel()
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
                new RouteInfosViewModel()
                {
                    Path = "/applications/goto",
                    Name = "apps.goto",
                    DrawerCategory = "Extension",
                    DrawerIcon = "supervised_user_circle",
                    DrawerLabel = "GoTo",
                    Exact = true,
                    Id = System.Guid.NewGuid(),
                    ShowOnDrawer = true,
                    Uri = "https://extension.localhost"
                }
            };

            return Ok(routes);
        }
    }
}
