using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using XXXXX.Admin.Core.Interfaces;

namespace XXXXX.Admin.API.Controllers
{
    [Route("api/admin/v1")]
    public class PermissionCategoriesController : AppController
    {
        private readonly IPermissionCategoryService _permissionCategoryService;

        public PermissionCategoriesController(IPermissionCategoryService permissionCategoryService)
        {
            _permissionCategoryService = permissionCategoryService;
        }

        [Route("permissions-categories")]
        [HttpGet]
        public async Task<IActionResult> GetMany()
        {
            var result = await _permissionCategoryService.GetMany(GetAppId(), GetActorId());
            return Ok(result);
        }
    }
}