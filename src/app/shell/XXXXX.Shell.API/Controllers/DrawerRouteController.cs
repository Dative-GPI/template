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
    [Route("api/drawer-routes")]
    public class DrawerRouteController : AppController
    {
        private IDrawerRouteService _drawerRouteService;

        public DrawerRouteController(IDrawerRouteService drawerRouteService)
        {
            _drawerRouteService = drawerRouteService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMany([FromQuery] DrawerRoutesFilterViewModel filter){
            var routes = await _drawerRouteService.GetMany(GetAppId(), GetActorId(), filter);

            return Ok(routes);
        }
    }
}
