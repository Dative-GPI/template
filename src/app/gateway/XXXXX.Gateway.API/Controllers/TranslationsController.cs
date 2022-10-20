using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using XXXXX.Gateway.Core.Interfaces;
using XXXXX.Gateway.Core.ViewModels;

namespace XXXXX.Gateway.API.Controllers
{
    [Route("api")]
    public class ApplicationTranslationsController : AppController
    {
        private IApplicationTranslationService _applicationTranslationService;

        public ApplicationTranslationsController(IApplicationTranslationService applicationTranslationService)
        {
            _applicationTranslationService = applicationTranslationService;
        }

        [HttpGet("translations")]
        public async Task<IActionResult> GetMany([FromQuery] TranslationSelectorViewModel selector)
        {
            var translations = await _applicationTranslationService.GetMany(GetApplicationId(), GetActorId(), GetLanguageCode(), selector.OrganisationId);
            return Ok(translations);
        }
    }
}
