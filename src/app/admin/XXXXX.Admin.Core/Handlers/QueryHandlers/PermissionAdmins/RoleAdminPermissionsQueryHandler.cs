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
    public class RoleAdminPermissionsQueryHandler : IMiddleware<RoleAdminPermissionsQuery, IEnumerable<PermissionAdminInfos>>
    {
        private IPermissionAdminRepository _permissionAdminRepository;
        private IRoleAdminPermissionRepository _roleAdminPermissionsRepository;

        public RoleAdminPermissionsQueryHandler(
            IRoleAdminPermissionRepository roleAdminPermissionsRepository,
            IPermissionAdminRepository permissionAdminRepository)
        {
            _permissionAdminRepository = permissionAdminRepository;
            _roleAdminPermissionsRepository = roleAdminPermissionsRepository;
        }

        public async Task<IEnumerable<PermissionAdminInfos>> HandleAsync(RoleAdminPermissionsQuery request, Func<Task<IEnumerable<PermissionAdminInfos>>> next, CancellationToken cancellationToken)
        {
            var filter = new RoleAdminPermissionsFilter()
            {
                RoleAdminId = request.RoleAdminId
            };

            var roleAdminPermissions = await _roleAdminPermissionsRepository.GetMany(filter);

            var permissionAdmins = await _permissionAdminRepository.GetMany(new PermissionAdminFilter()
            {
                PermissionAdminIds = roleAdminPermissions.Select(rp => rp.PermissionAdminId)
            });

            return roleAdminPermissions.Join(
                permissionAdmins,
                rp => rp.PermissionAdminId,
                p => p.Id,
                (rp, p) => p
            );
        }
    }
}