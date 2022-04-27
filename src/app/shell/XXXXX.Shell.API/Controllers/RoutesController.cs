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
        public async Task<IActionResult> GetMany([FromQuery] RoutesFilterViewModel filter){
            var routes = await _routeService.GetMany(GetAppId(), GetActorId(), filter);

            return Ok(routes);
        }
    }
}
