using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

using XXXXX.Admin.Core.Interfaces;
using XXXXX.Admin.Core.ViewModels;

namespace XXXXX.Admin.API.Controllers
{
    [Route("api/admin/v1")]
    public class RolePermissionscontroller : AppController
    {
        private readonly IRolePermissionService _rolePermissionService;

        public RolePermissionscontroller(IRolePermissionService rolePermissionService)
        {
            _rolePermissionService = rolePermissionService;
        }
        
        [Route("roles/{roleId:Guid}/permissions")]
        [HttpGet]
        public async Task<IActionResult> GetMany([FromRoute] Guid roleId)
        {
            var result = await _rolePermissionService.GetMany(GetAppId(), GetActorId(), roleId);
            return Ok(result);
        }

        [Route("roles/{roleId:Guid}/permissions")]
        [HttpPost]
        public async Task<IActionResult> Update([FromRoute] Guid roleId, [FromBody] List<Guid> payload)
        {
            await _rolePermissionService.Update(GetAppId(), GetActorId(), roleId, payload);
            return Ok();
        }
    }
}