using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using XXXXX.Shell.Core.Interfaces;

namespace XXXXX.Shell.API.Controllers
{
    [Route("api/v1/XXXXX")]
    public class RolePermissionsController : AppController
    {
        private readonly IRolePermissionService _rolePermissionService;

        public RolePermissionsController(IRolePermissionService rolePermissionService)
        {
            _rolePermissionService = rolePermissionService;
        }

        [Route("organisations/{organisationId:Guid}/roles/{roleId:Guid}/permissions")]
        [HttpGet]
        public async Task<IActionResult> GetMany([FromRoute] Guid organisationId, [FromRoute] Guid roleId)
        {
            var result = await _rolePermissionService.GetMany(GetRequestHeaders(), organisationId, roleId);
            return Ok(result);
        }

        [Route("organisations/{organisationId:Guid}/roles/{roleId:Guid}/permissions")]
        [HttpPost]
        public async Task<IActionResult> Update([FromRoute] Guid organisationId, [FromRoute] Guid roleId, [FromBody] List<Guid> payload)
        {
            await _rolePermissionService.Update(GetRequestHeaders(), organisationId, roleId, payload);
            return Ok();
        }
    }
}