using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Bones.Flow;

using XXXXX.Domain.Models;
using XXXXX.Domain.Repositories.Filters;
using XXXXX.Domain.Repositories.Interfaces;

namespace XXXXX.Admin.Core.Handlers
{
    public class PermissionAdminCategoriesQueryHandler : IMiddleware<PermissionAdminCategoriesQuery, IEnumerable<PermissionAdminCategory>>
    {
        private IPermissionAdminCategoryRepository _permissionAdminCategoryRepository;
        
        public PermissionAdminCategoriesQueryHandler(IPermissionAdminCategoryRepository permissionAdminCategoryRepository)
        {
            _permissionAdminCategoryRepository = permissionAdminCategoryRepository;
        }

        public async Task<IEnumerable<PermissionAdminCategory>> HandleAsync(PermissionAdminCategoriesQuery request, Func<Task<IEnumerable<PermissionAdminCategory>>> next, CancellationToken cancellationToken)
        {
            return await _permissionAdminCategoryRepository.GetMany();
        }
    }
}