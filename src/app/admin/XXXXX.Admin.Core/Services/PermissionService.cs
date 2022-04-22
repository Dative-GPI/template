using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using AutoMapper;

using Bones.Flow;

using XXXXX.Domain.Models;

using XXXXX.Admin.Core.Interfaces;
using XXXXX.Admin.Core.ViewModels;
using XXXXX.Domain.Repositories.Interfaces;

namespace XXXXX.Admin.Core.Services
{
    public class PermissionService : IPermissionService
    {
        private IQueryHandler<PermissionsQuery, IEnumerable<PermissionInfos>> _permissionsQueryHandler;
        private IPermissionRepository _permissionRepository;
        private IMapper _mapper;

        public PermissionService(
            IQueryHandler<PermissionsQuery, IEnumerable<PermissionInfos>> permissionsQuery,
            IPermissionRepository permissionRepository,
            IMapper mapper
        )
        {
            _permissionsQueryHandler = permissionsQuery;
            _permissionRepository = permissionRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PermissionCategoryViewModel>> GetCategories(Guid appId, Guid actorId)
        {
            var result = await _permissionRepository.GetCategories();

            return _mapper.Map<IEnumerable<PermissionCategory>, IEnumerable<PermissionCategoryViewModel>>(result);
        }

        public async Task<IEnumerable<PermissionInfosViewModel>> GetMany(Guid appId, Guid actorId, PermissionsFilterViewModel filter)
        {
            var query = new PermissionsQuery()
            {
                ApplicationId = appId,
                ActorId = actorId,
                Search = filter.Search
            };

            var result = await _permissionsQueryHandler.HandleAsync(query);

            return _mapper.Map<IEnumerable<PermissionInfos>, IEnumerable<PermissionInfosViewModel>>(result);
        }
    }
}