using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

using XXXXX.Admin.Core.Interfaces;

namespace XXXXX.Admin.API.Controllers
{
    [Route("api/admin/v1")]
    public class OrganisationTypePermissionController : AppController
    {
        private readonly IOrganisationTypePermissionService _organisationTypePermissionService;

        public OrganisationTypePermissionController(IOrganisationTypePermissionService organisationTypePermissionService)
        {
            _organisationTypePermissionService = organisationTypePermissionService;
        }
        
        [Route("organisation-types/{organisationTypeId:Guid}/permissions")]
        [HttpGet]
        public async Task<IActionResult> GetMany([FromRoute] Guid organisationTypeId)
        {
            var result = await _organisationTypePermissionService.GetMany(GetAppId(), GetActorId(), organisationTypeId);
            return Ok(result);
        }

        [Route("organisation-types/{organisationTypeId:Guid}/permissions")]
        [HttpPost]
        public async Task<IActionResult> Update([FromRoute] Guid organisationTypeId, [FromBody] List<Guid> payload)
        {
            await _organisationTypePermissionService.Update(GetAppId(), GetActorId(), organisationTypeId, payload);
            return Ok();
        }
    }
}