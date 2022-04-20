using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using XXXXX.shell.Core.Interfaces;
using XXXXX.Shell.Core;
using XXXXX.Shell.Core.ViewModels;

namespace XXXXX.Shell.API.Controllers
{
    [Route("api/admin")]
    public class RouteController : AppController
    {
        private IRouteService _routeService;

        public RouteController(IRouteService routeService)
        {
            _routeService = routeService;
        }

        [HttpGet("routes")]
        public async Task<IActionResult> GetMany([FromQuery] RoutesFilterViewModel filter){
            var routes = await _routeService.GetMany(GetAppId(), GetActorId(), filter);

            return Ok(routes);
        }
    }
}
