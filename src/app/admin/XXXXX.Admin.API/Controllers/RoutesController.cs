using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using XXXXX.Admin.Core.Interfaces;
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
        public async Task<IActionResult> GetMany([FromQuery] RoutesFilterViewModel filter)
        {
            var routes = await _routeService.GetMany(GetAppId(), GetActorId(), filter);
            return Ok(routes);
        }
    }
}
