using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Bones.Flow;

using XXXXX.Domain.Models;
using XXXXX.Domain.Repositories.Filters;
using XXXXX.Domain.Repositories.Interfaces;

namespace XXXXX.Shell.Core.Handlers {
    public class RolePermissionsQueryHandler : IMiddleware<RolePermissionsQuery, IEnumerable<PermissionInfos>>
    {
        private readonly IPermissionRepository _permissionRepository;

        public RolePermissionsQueryHandler(
            IPermissionRepository permissionRepository
        )
        {
            _permissionRepository = permissionRepository;
        }

        public async Task<IEnumerable<PermissionInfos>> HandleAsync(RolePermissionsQuery request, Func<Task<IEnumerable<PermissionInfos>>> next, CancellationToken cancellationToken)
        {
            var permissions = await _permissionRepository.GetMany(new PermissionsFilter() {
                RoleId = request.RoleId
            });

            return permissions;
        }
    }
}