using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using XXXXX.Shell.Core.ViewModels;
using XXXXX.Shell.Core.Interfaces;

namespace XXXXX.Shell.API.Controllers
{
    [Route("api")]
    public class RoutesController : AppController
    {
        private IRouteService _routeService;

        public RoutesController(IRouteService routeService)
        {
            _routeService = routeService;
        }

        [HttpGet("organisations/{organisationId:Guid}/routes")]
        public async Task<IActionResult> GetMany(Guid organisationId,[FromQuery] RoutesFilterViewModel filter)
        {
            var routes = await _routeService.GetMany(GetRequestHeaders(), organisationId, filter);
            return Ok(routes);
        }
    }
}
