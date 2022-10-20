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
    public class RoleAdminPermissionService : IRoleAdminPermissionService
    {
        private IQueryHandler<RoleAdminPermissionsQuery, IEnumerable<PermissionAdminInfos>> _roleAdminPermissionsQueryHandler;
        private ICommandHandler<UpdateRoleAdminPermissionsCommand> _updateRoleAdminPermissionsCommand;
        private IMapper _mapper;

        public RoleAdminPermissionService(
            IQueryHandler<RoleAdminPermissionsQuery, IEnumerable<PermissionAdminInfos>> rolePermissionsQuery,
            ICommandHandler<UpdateRoleAdminPermissionsCommand> updateRolePermissionsCommand,
            IMapper mapper
        )
        {
            _roleAdminPermissionsQueryHandler = rolePermissionsQuery;
            _updateRoleAdminPermissionsCommand = updateRolePermissionsCommand;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PermissionAdminInfosViewModel>> GetMany(Guid appId, Guid actorId, Guid roleAdminId)
        {
            var query = new RoleAdminPermissionsQuery()
            {
                ApplicationId = appId,
                ActorId = actorId,
                RoleAdminId = roleAdminId
            };

            var result = await _roleAdminPermissionsQueryHandler.HandleAsync(query);

            return _mapper.Map<IEnumerable<PermissionAdminInfos>, IEnumerable<PermissionAdminInfosViewModel>>(result);
        }

        public async Task Update(Guid appId, Guid actorId, Guid roleAdminId, List<Guid> payload)
        {
            var command = new UpdateRoleAdminPermissionsCommand()
            {
                ApplicationId = appId,
                ActorId = actorId,

                RoleAdminId = roleAdminId,
                PermissionAdminsIds = payload
            };

            await _updateRoleAdminPermissionsCommand.HandleAsync(command);
        }
    }
}