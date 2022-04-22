using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

using XXXXX.Admin.Core.Interfaces;
using XXXXX.Admin.Core.ViewModels;

namespace XXXXX.Admin.API.Controllers
{
    [Route("api/admin/v1")]
    public class PermissionOrganisationTypesController : AppController
    {
        private readonly IPermissionOrganisationTypeService _permissionOrganisationTypeService;

        public PermissionOrganisationTypesController(IPermissionOrganisationTypeService permissionOrganisationTypeService)
        {
            _permissionOrganisationTypeService = permissionOrganisationTypeService;
        }
        
        [Route("organisation-types/{organisationTypeId:Guid}/permissions")]
        [HttpGet]
        public async Task<IActionResult> GetMany([FromRoute] Guid organisationTypeId)
        {
            var result = await _permissionOrganisationTypeService.GetMany(GetAppId(), GetActorId(), organisationTypeId);
            return Ok(result);
        }

        [Route("organisation-types/{organisationTypeId:Guid}/permissions")]
        [HttpPost]
        public async Task<IActionResult> Update([FromRoute] Guid organisationTypeId, [FromBody] List<Guid> payload)
        {
            await _permissionOrganisationTypeService.Update(GetAppId(), GetActorId(), organisationTypeId, payload);
            return Ok();
        }
    }
}