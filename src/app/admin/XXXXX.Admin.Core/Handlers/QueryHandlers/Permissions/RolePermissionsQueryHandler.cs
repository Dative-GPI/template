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
    public class RolePermissionsQueryHandler : IMiddleware<RolePermissionsQuery, IEnumerable<PermissionInfos>>
    {
        private IPermissionRepository _permissionRepository;
        private IRolePermissionRepository _rolePermissionsRepository;

        public RolePermissionsQueryHandler(
            IRolePermissionRepository rolePermissionsRepository,
            IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;
            _rolePermissionsRepository = rolePermissionsRepository;
        }

        public async Task<IEnumerable<PermissionInfos>> HandleAsync(RolePermissionsQuery request, Func<Task<IEnumerable<PermissionInfos>>> next, CancellationToken cancellationToken)
        {
            var filter = new RolePermissionsFilter()
            {
                RoleId = request.RoleId
            };

            var rolePermissions = await _rolePermissionsRepository.GetMany(filter);

            var permissions = await _permissionRepository.GetMany(new PermissionsFilter()
            {
                Ids = rolePermissions.Select(p => p.PermissionId)
            });

            return permissions;
        }
    }
}