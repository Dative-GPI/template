using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

using XXXXX.Admin.Core.Interfaces;

namespace XXXXX.Admin.API.Controllers
{
    [Route("api/admin/v1")]
    public class RoleAdminPermissionsController : AppController
    {
        private readonly IRoleAdminPermissionService _roleAdminPermissionService;

        public RoleAdminPermissionsController(IRoleAdminPermissionService roleAdminPermissionService)
        {
            _roleAdminPermissionService = roleAdminPermissionService;
        }
        
        [Route("roles-admin/{roleAdminId:Guid}/permissions")]
        [HttpGet]
        public async Task<IActionResult> GetMany([FromRoute] Guid roleAdminId)
        {
            var result = await _roleAdminPermissionService.GetMany(GetAppId(), GetActorId(), roleAdminId);
            return Ok(result);
        }

        [Route("roles-admin/{roleAdminId:Guid}/permissions")]
        [HttpPost]
        public async Task<IActionResult> Update([FromRoute] Guid roleAdminId, [FromBody] List<Guid> payload)
        {
            await _roleAdminPermissionService.Update(GetAppId(), GetActorId(), roleAdminId, payload);
            return Ok();
        }
    }
}