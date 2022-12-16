using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using AutoMapper;

using Bones.Flow;

using XXXXX.Domain.Models;

using XXXXX.Admin.Core.Interfaces;
using XXXXX.Admin.Core.ViewModels;
using XXXXX.Admin.Core.Abstractions;

namespace XXXXX.Admin.Core.Services
{
    public class PermissionAdminService : IPermissionAdminService
    {
        private IQueryHandler<PermissionAdminsQuery, IEnumerable<PermissionAdminInfos>> _permissionAdminsQueryHandler;
        private IPermissionProvider _permissionProvider;
        private IMapper _mapper;

        public PermissionAdminService(
            IQueryHandler<PermissionAdminsQuery, IEnumerable<PermissionAdminInfos>> permissionAdminsQueryHandler,
            IPermissionProvider permissionProvider,
            IMapper mapper
        )
        {
            _permissionAdminsQueryHandler = permissionAdminsQueryHandler;
            _permissionProvider = permissionProvider;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PermissionAdminInfosViewModel>> GetMany(Guid appId, Guid actorId, PermissionAdminFilterViewModel filter)
        {
            var query = new PermissionAdminsQuery()
            {
                ApplicationId = appId,
                ActorId = actorId,

                Search = filter.Search,
                RoleAdminId = filter.RoleAdminId,
                PermissionAdminIds = filter.PermissionAdminIds
            };

            var result = await _permissionAdminsQueryHandler.HandleAsync(query);

            return _mapper.Map<IEnumerable<PermissionAdminInfos>, IEnumerable<PermissionAdminInfosViewModel>>(result);
        }

        public async Task<IEnumerable<string>> GetCurrent(Guid appId, Guid actorId)
        {
            return await _permissionProvider.GetPermissions(actorId);
        }
    }
}