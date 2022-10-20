using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

using XXXXX.Admin.Core.Interfaces;
using XXXXX.Admin.Core.ViewModels;

namespace XXXXX.Admin.API.Controllers
{
    [Route("api/admin/v1")]
    public class PermissionsController : AppController
    {
        private readonly IPermissionService _permissionService;

        public PermissionsController(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        [Route("permissions")]
        [HttpGet]
        public async Task<IActionResult> GetMany([FromQuery] PermissionsFilterViewModel filter)
        {
            var result = await _permissionService.GetMany(GetAppId(), GetActorId(), filter);
            return Ok(result);
        }
    }
}