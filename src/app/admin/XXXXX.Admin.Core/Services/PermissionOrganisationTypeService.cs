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
    public class PermissionOrganisationTypeService : IPermissionOrganisationTypeService
    {
        private IQueryHandler<PermissionOrganisationTypesQuery, IEnumerable<PermissionInfos>> _permissionOrganisationTypesQueryHandler;
        private ICommandHandler<UpdatePermissionOrganisationTypesCommand> _updatePermissionOrganisationTypesCommand;
        private IPermissionRepository _permissionRepository;
        private IMapper _mapper;

        public PermissionOrganisationTypeService(
            IQueryHandler<PermissionOrganisationTypesQuery, IEnumerable<PermissionInfos>> permissionOrganisationTypesQuery,
            ICommandHandler<UpdatePermissionOrganisationTypesCommand> updatePermissionOrganisationTypesCommand,
            IPermissionRepository permissionRepository,
            IMapper mapper
        ) {
            _permissionOrganisationTypesQueryHandler = permissionOrganisationTypesQuery;
            _updatePermissionOrganisationTypesCommand = updatePermissionOrganisationTypesCommand;
            _permissionRepository = permissionRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PermissionInfosViewModel>> GetMany(Guid appId, Guid actorId, Guid organisationTypeId)
        {
            var query = new PermissionOrganisationTypesQuery(){
                ApplicationId = appId,
                ActorId = actorId,
                OrganisationTypeId = organisationTypeId
            };

            var result = await _permissionOrganisationTypesQueryHandler.HandleAsync(query);

            return _mapper.Map<IEnumerable<PermissionInfos>, IEnumerable<PermissionInfosViewModel>>(result);
        }

        public async Task Update(Guid appId, Guid actorId, Guid organisationTypeId, List<Guid> payload)
        {
            var command = new UpdatePermissionOrganisationTypesCommand()
            {
                ApplicationId = appId,
                ActorId = actorId,

                OrganisationTypeId = organisationTypeId,
                PermissionsIds = payload
            };

            await _updatePermissionOrganisationTypesCommand.HandleAsync(command);
        }
    }
}