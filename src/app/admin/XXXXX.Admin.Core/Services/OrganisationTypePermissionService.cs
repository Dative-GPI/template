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
    public class OrganisationTypePermissionService : IOrganisationTypePermissionService
    {
        private IQueryHandler<OrganisationTypePermissionsQuery, IEnumerable<PermissionInfos>> _organisationTypePermissionsQueryHandler;
        private ICommandHandler<UpdateOrganisationTypePermissionsCommand> _updateOrganisationTypePermissionsCommand;
        private IPermissionRepository _permissionRepository;
        private IMapper _mapper;

        public OrganisationTypePermissionService(
            IQueryHandler<OrganisationTypePermissionsQuery, IEnumerable<PermissionInfos>> organisationTypePermissionsQuery,
            ICommandHandler<UpdateOrganisationTypePermissionsCommand> updateOrganisationTypePermissionsCommand,
            IPermissionRepository permissionRepository,
            IMapper mapper
        ) {
            _organisationTypePermissionsQueryHandler = organisationTypePermissionsQuery;
            _updateOrganisationTypePermissionsCommand = updateOrganisationTypePermissionsCommand;
            _permissionRepository = permissionRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PermissionInfosViewModel>> GetMany(Guid appId, Guid actorId, Guid organisationTypeId)
        {
            var query = new OrganisationTypePermissionsQuery(){
                ApplicationId = appId,
                ActorId = actorId,
                OrganisationTypeId = organisationTypeId
            };

            var result = await _organisationTypePermissionsQueryHandler.HandleAsync(query);

            return _mapper.Map<IEnumerable<PermissionInfos>, IEnumerable<PermissionInfosViewModel>>(result);
        }

        public async Task Update(Guid appId, Guid actorId, Guid organisationTypeId, List<Guid> payload)
        {
            var command = new UpdateOrganisationTypePermissionsCommand()
            {
                ApplicationId = appId,
                ActorId = actorId,

                OrganisationTypeId = organisationTypeId,
                PermissionsIds = payload
            };

            await _updateOrganisationTypePermissionsCommand.HandleAsync(command);
        }
    }
}