using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using XXXXX.admin.Core.Interfaces;
using XXXXX.Admin.Core;
using XXXXX.Admin.Core.ViewModels;

namespace XXXXX.Admin.API.Controllers
{
    [Route("api/admin/routes")]
    public class RouteController : AppController
    {
        private IRouteService _routeService;

        public RouteController(IRouteService routeService)
        {
            _routeService = routeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMany([FromQuery] RoutesFilterViewModel filter){
            var routes = await _routeService.GetMany(GetAppId(), GetActorId(), filter);

            return Ok(routes);
        }
    }
}
