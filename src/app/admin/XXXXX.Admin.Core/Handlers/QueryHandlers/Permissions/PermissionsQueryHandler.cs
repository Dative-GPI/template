using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Bones.Flow;

using XXXXX.Domain.Models;
using XXXXX.Domain.Repositories.Filters;
using XXXXX.Domain.Repositories.Interfaces;

namespace XXXXX.Admin.Core.Handlers
{
    public class PermissionsQueryHandler : IMiddleware<PermissionsQuery, IEnumerable<PermissionInfos>>
    {
        private IPermissionRepository _permissionRepository;
        
        public PermissionsQueryHandler(IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;
        }

        public async Task<IEnumerable<PermissionInfos>> HandleAsync(PermissionsQuery request, Func<Task<IEnumerable<PermissionInfos>>> next, CancellationToken cancellationToken)
        {
            var filter = new PermissionsFilter()
            {
                Search = request.Search,
                OrganisationTypeId = request.OrganisationTypeId,
                RoleId = request.RoleId,
                PermissionIds = request.PermissionIds
            };

            return await _permissionRepository.GetMany(filter);
        }
    }
}