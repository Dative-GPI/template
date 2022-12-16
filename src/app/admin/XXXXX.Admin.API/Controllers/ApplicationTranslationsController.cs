using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

using XXXXX.Admin.Core.Interfaces;
using XXXXX.Admin.Core.ViewModels;

namespace XXXXX.Admin.API.Controllers
{
    [Route("api/admin/v1")]
    public class ApplicationTranslationsController : AppController
    {
        private IApplicationTranslationService _applicationTranslationService;

        public ApplicationTranslationsController(IApplicationTranslationService applicationTranslationService)
        {
            _applicationTranslationService = applicationTranslationService;
        }

        [HttpGet("application-translations")]
        public async Task<IActionResult> GetMany()
        {
            var translations = await _applicationTranslationService.GetMany(GetRequestHeaders());
            return Ok(translations);
        }

        [HttpPost("application-translations")]
        public async Task<IActionResult> UpdateRange([FromBody]IEnumerable<UpdateApplicationTranslationViewModel> payload)
        {
            await _applicationTranslationService.UpdateRange(GetRequestHeaders(), payload);
            return Ok();
        }
    }
}
