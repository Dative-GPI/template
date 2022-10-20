using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using XXXXX.Admin.Core.Interfaces;

namespace XXXXX.Admin.API.Controllers
{
    [Route("api/admin/v1")]
    public class PermissionAdminCategoriesController : AppController
    {
        private readonly IPermissionAdminCategoryService _permissionAdminCategoryService;

        public PermissionAdminCategoriesController(IPermissionAdminCategoryService permissionAdminCategoryService)
        {
            _permissionAdminCategoryService = permissionAdminCategoryService;
        }

        [Route("permission-admin-categories")]
        [HttpGet]
        public async Task<IActionResult> GetMany()
        {
            var result = await _permissionAdminCategoryService.GetMany(GetAppId(), GetActorId());
            return Ok(result);
        }
    }
}