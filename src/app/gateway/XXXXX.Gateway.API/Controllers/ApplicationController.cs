using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using XXXXX.Gateway.Core.Interfaces;
using XXXXX.Gateway.Core.ViewModels;

namespace XXXXX.Gateway.API.Controllers
{
    [Route("api")]
    public class ApplicationController : AppController
    {
        private readonly IApplicationService _applicationService;

        public ApplicationController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [Route("applications")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Install([FromBody]CreateApplicationViewModel payload)
        {
            var result = await _applicationService.Create(payload);

            return Ok(result);
        }

        [Route("applications/{applicationId:Guid}")]
        [AllowAnonymous]
        [HttpDelete]
        public async Task<IActionResult> Uninstall([FromRoute]Guid applicationId)
        {
            await _applicationService.Remove(GetActorId(), applicationId);
            return Ok();
        }
    }
}