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
    public class PermissionCategoryService : IPermissionCategoryService
    {
        private IQueryHandler<PermissionCategoriesQuery, IEnumerable<PermissionCategory>> _permissionCategoriesQueryHandler;
        private IMapper _mapper;

        public PermissionCategoryService(
            IQueryHandler<PermissionCategoriesQuery, IEnumerable<PermissionCategory>> permissionCategoriesQueryHandler,
            IMapper mapper
        )
        {
            _permissionCategoriesQueryHandler = permissionCategoriesQueryHandler;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PermissionCategoryViewModel>> GetMany(Guid appId, Guid actorId)
        {
            var query = new PermissionCategoriesQuery() {
                ApplicationId = appId,
                ActorId = actorId
            };

            var result = await _permissionCategoriesQueryHandler.HandleAsync(query);

            return _mapper.Map<IEnumerable<PermissionCategory>, IEnumerable<PermissionCategoryViewModel>>(result);
        }
    }
}