using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using XXXXX.Shell.Core.Interfaces;

namespace XXXXX.Shell.API.Controllers
{
    [Route("api/v1")]
    public class PermissionsController : AppController
    {
        private readonly IPermissionService _permissionService;

        public PermissionsController(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        [Route("organisations/{organisationId:Guid}/permissions/current")]
        [HttpGet]
        public async Task<IActionResult> GetCurrent([FromRoute] Guid organisationId)
        {
            var result = await _permissionService.GetCurrent(GetRequestHeaders(), organisationId);
            return Ok(result);
        }

        [Route("organisations/{organisationId:Guid}/permissions/categories")]
        [HttpGet]
        public async Task<IActionResult> GetCategories([FromRoute] Guid organisationId)
        {
            var result = await _permissionService.GetCategories(GetRequestHeaders(), organisationId);
            return Ok(result);
        }
    }
}