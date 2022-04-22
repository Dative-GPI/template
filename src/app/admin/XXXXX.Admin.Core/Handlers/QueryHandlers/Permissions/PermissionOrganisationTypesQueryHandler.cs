using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Bones.Flow;

using XXXXX.Domain.Models;
using XXXXX.Domain.Repositories.Filters;
using XXXXX.Domain.Repositories.Interfaces;

namespace XXXXX.Admin.Core.Handlers
{
    public class PermissionOrganisationTypesQueryHandler : IMiddleware<PermissionOrganisationTypesQuery, IEnumerable<PermissionInfos>>
    {
        private IPermissionRepository _permissionRepository;
        private IPermissionOrganisationTypeRepository _organisationTypePermissionRepository;

        public PermissionOrganisationTypesQueryHandler(
            IPermissionOrganisationTypeRepository organisationTypePermissionRepository,
            IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;
            _organisationTypePermissionRepository = organisationTypePermissionRepository;
        }

        public async Task<IEnumerable<PermissionInfos>> HandleAsync(PermissionOrganisationTypesQuery request, Func<Task<IEnumerable<PermissionInfos>>> next, CancellationToken cancellationToken)
        {
            var filter = new PermissionOrganisationTypesFilter()
            {
                OrganisationTypeId = request.OrganisationTypeId
            };

            var orgTypePermissions = await _organisationTypePermissionRepository.GetMany(filter);

            var permissions = await _permissionRepository.GetMany(new PermissionsFilter()
            {
                Ids = orgTypePermissions.Select(p => p.PermissionId)
            });

            return permissions;
        }
    }
}