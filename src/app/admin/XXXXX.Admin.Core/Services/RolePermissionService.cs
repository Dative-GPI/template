using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using AutoMapper;

using Bones.Flow;

using XXXXX.Domain.Models;
using XXXXX.Domain.Repositories.Interfaces;

using XXXXX.Admin.Core.Interfaces;
using XXXXX.Admin.Core.ViewModels;
using XXXXX.Domain.Repositories.Filters;

namespace XXXXX.Admin.Core.Services
{
    public class RolePermissionService : IRolePermissionService
    {
        private IQueryHandler<RolePermissionsQuery, IEnumerable<PermissionInfos>> _rolePermissionsQueryHandler;
        private ICommandHandler<UpdateRolePermissionsCommand> _updateRolePermissionsCommand;        private IMapper _mapper;

        public RolePermissionService(
            IQueryHandler<RolePermissionsQuery, IEnumerable<PermissionInfos>> rolePermissionsQuery,
            ICommandHandler<UpdateRolePermissionsCommand> updateRolePermissionsCommand,
            IPermissionRepository permissionRepository,
            IMapper mapper
        ) {
            _rolePermissionsQueryHandler = rolePermissionsQuery;
            _updateRolePermissionsCommand = updateRolePermissionsCommand;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PermissionInfosViewModel>> GetMany(Guid appId, Guid actorId, Guid organisationTypeId)
        {
            var query = new RolePermissionsQuery(){
                ApplicationId = appId,
                ActorId = actorId,
                RoleId = organisationTypeId
            };

            var result = await _rolePermissionsQueryHandler.HandleAsync(query);

            return _mapper.Map<IEnumerable<PermissionInfos>, IEnumerable<PermissionInfosViewModel>>(result);
        }

        public async Task Update(Guid appId, Guid actorId, Guid organisationTypeId, List<Guid> payload)
        {
            var command = new UpdateRolePermissionsCommand()
            {
                ApplicationId = appId,
                ActorId = actorId,

                RoleId = organisationTypeId,
                PermissionsIds = payload
            };

            await _updateRolePermissionsCommand.HandleAsync(command);
        }
    }
}