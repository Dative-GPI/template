using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using XXXXX.Admin.Core.Interfaces;
using XXXXX.Admin.Core.ViewModels;

namespace XXXXX.Admin.API.Controllers
{
    [Route("api/admin/v1")]
    public class PermissionAdminsController : AppController
    {
        private readonly IPermissionAdminService _permissionAdminService;

        public PermissionAdminsController(IPermissionAdminService permissionAdminService)
        {
            _permissionAdminService = permissionAdminService;
        }

        [Route("permissions-admin")]
        [HttpGet]
        public async Task<IActionResult> GetMany([FromQuery] PermissionAdminFilterViewModel filter)
        {
            var result = await _permissionAdminService.GetMany(GetAppId(), GetActorId(), filter);
            return Ok(result);
        }

        [Route("permissions-admin/current")]
        [HttpGet]
        public async Task<IActionResult> GetCurrent()
        {
            var result = await _permissionAdminService.GetCurrent(GetAppId(), GetActorId());
            return Ok(result);
        }
    }
}