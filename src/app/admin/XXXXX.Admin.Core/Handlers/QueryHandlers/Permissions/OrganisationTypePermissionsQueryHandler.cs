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
    public class OrganisationTypePermissionsQueryHandler : IMiddleware<OrganisationTypePermissionsQuery, IEnumerable<PermissionInfos>>
    {
        private IPermissionRepository _permissionRepository;
        private IOrganisationTypePermissionRepository _organisationTypePermissionRepository;

        public OrganisationTypePermissionsQueryHandler(
            IOrganisationTypePermissionRepository organisationTypePermissionRepository,
            IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;
            _organisationTypePermissionRepository = organisationTypePermissionRepository;
        }

        public async Task<IEnumerable<PermissionInfos>> HandleAsync(OrganisationTypePermissionsQuery request, Func<Task<IEnumerable<PermissionInfos>>> next, CancellationToken cancellationToken)
        {
            var filter = new OrganisationTypePermissionsFilter()
            {
                OrganisationTypeId = request.OrganisationTypeId
            };

            var orgTypePermissions = await _organisationTypePermissionRepository.GetMany(filter);

            var permissions = await _permissionRepository.GetMany(new PermissionsFilter()
            {
                PermissionIds = orgTypePermissions.Select(p => p.PermissionId)
            });

            return permissions;
        }
    }
}