using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using XXXXX.Admin.Core.Interfaces;

namespace XXXXX.Admin.API.Controllers
{
    [Route("api/admin/v1")]
    public class TranslationsController : AppController
    {
        private ITranslationService _translationService;

        public TranslationsController(ITranslationService translationService)
        {
            _translationService = translationService;
        }

        [HttpGet("translations")]
        public async Task<IActionResult> GetMany(Guid organisationId)
        {
            var translations = await _translationService.GetMany(GetRequestHeaders());
            return Ok(translations);
        }
    }
}
