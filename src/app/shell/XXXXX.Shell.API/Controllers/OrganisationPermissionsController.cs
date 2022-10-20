using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using XXXXX.Shell.Core.Interfaces;

namespace XXXXX.Shell.API.Controllers
{
    [Route("api/v1/XXXXX")]
    public class OrganisationPermissionsController : AppController
    {
        private readonly IOrganisationPermissionService _organisationPermissionService;

        public OrganisationPermissionsController(IOrganisationPermissionService organisationPermissionService)
        {
            _organisationPermissionService = organisationPermissionService;
        }

        [Route("organisations/{organisationId:Guid}/permissions")]
        [HttpGet]
        public async Task<IActionResult> GetMany([FromRoute] Guid organisationId)
        {
            var result = await _organisationPermissionService.GetMany(GetRequestHeaders(), organisationId);
            return Ok(result);
        }
    }
}