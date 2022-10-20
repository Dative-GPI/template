using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using AutoMapper;

using Bones.Flow;

using XXXXX.Domain.Models;

using XXXXX.Admin.Core.Interfaces;
using XXXXX.Admin.Core.ViewModels;

namespace XXXXX.Admin.Core.Services
{
    public class PermissionAdminCategoryService : IPermissionAdminCategoryService
    {
        private IQueryHandler<PermissionAdminCategoriesQuery, IEnumerable<PermissionAdminCategory>> _permissionAdminCategoriesQueryHandler;
        private IMapper _mapper;

        public PermissionAdminCategoryService(
            IQueryHandler<PermissionAdminCategoriesQuery, IEnumerable<PermissionAdminCategory>> permissionAdminCategoriesQueryHandler,
            IMapper mapper
        )
        {
            _permissionAdminCategoriesQueryHandler = permissionAdminCategoriesQueryHandler;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PermissionAdminCategoryViewModel>> GetMany(Guid appId, Guid actorId)
        {
            var query = new PermissionAdminCategoriesQuery() {
                ApplicationId = appId,
                ActorId = actorId
            };

            var result = await _permissionAdminCategoriesQueryHandler.HandleAsync(query);

            return _mapper.Map<IEnumerable<PermissionAdminCategory>, IEnumerable<PermissionAdminCategoryViewModel>>(result);
        }
    }
}