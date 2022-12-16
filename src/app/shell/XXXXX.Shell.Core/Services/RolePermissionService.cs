using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;
using Bones.Flow;

using XXXXX.Domain.Models;
using XXXXX.Shell.Core.Abstractions;
using XXXXX.Shell.Core.Interfaces;
using XXXXX.Shell.Core.ViewModels;

using static XXXXX.Shell.Core.AutoMapper.Consts;

namespace XXXXX.Shell.Core.Services
{
    public class RolePermissionService : IRolePermissionService
    {
        private readonly IQueryHandler<RolePermissionsQuery, IEnumerable<PermissionInfos>> _rolePermissionsQueryHandler;
        private readonly ICommandHandler<UpdateRolePermissionsCommand> _updateRolePermissionsCommandHandler;
        private readonly IMapper _mapper;

        public RolePermissionService(
            IQueryHandler<RolePermissionsQuery, IEnumerable<PermissionInfos>> rolePermissionsQueryHandler,
            ICommandHandler<UpdateRolePermissionsCommand> updateRolePermissionsCommandHandler,
            IMapper mapper
        )
        {
            _rolePermissionsQueryHandler = rolePermissionsQueryHandler;
            _updateRolePermissionsCommandHandler = updateRolePermissionsCommandHandler;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PermissionInfosViewModel>> GetMany(RequestHeaders headers, Guid organisationId, Guid roleId)
        {
            var query = new RolePermissionsQuery() {
                ApplicationId = headers.ApplicationId,
                ActorId = headers.ActorId,
                OrganisationId = organisationId,
                RoleId = roleId
            };

            var permissions = await _rolePermissionsQueryHandler.HandleAsync(query);

            return _mapper.Map<IEnumerable<PermissionInfos>, IEnumerable<PermissionInfosViewModel>>(permissions, opt => opt.Items.Add(LANGUAGE, headers.LanguageCode));
        }

        public async Task Update(RequestHeaders headers, Guid organisationId, Guid roleId, List<Guid> payload)
        {
            var command = new UpdateRolePermissionsCommand() {
                ActorId = headers.ActorId,
                ApplicationId = headers.ApplicationId,
                OrganisationId = organisationId,
                RoleId = roleId,
                PermissionsIds = payload
            };

            await _updateRolePermissionsCommandHandler.HandleAsync(command);
        }
    }
}