using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Foundation.Clients.ViewModels.Admin;
using Foundation.Clients.Abstractions;

using XXXXX.Domain.Repositories.Filters;
using XXXXX.Domain.Repositories.Interfaces;
using XXXXX.Admin.Core.Abstractions;

namespace XXXXX.Admin.Core.Tools
{
    public class PermissionProvider : IPermissionProvider
    {
        private readonly IFoundationClientFactory _foundationClientFactory;
        private readonly IRoleAdminPermissionRepository _roleAdminPermissionRepository;

        public PermissionProvider(
            IFoundationClientFactory foundationClientFactory,
            IRoleAdminPermissionRepository roleAdminPermissionRepository
        )
        {
            _foundationClientFactory = foundationClientFactory;
            _roleAdminPermissionRepository = roleAdminPermissionRepository;
        }


        public async Task<bool> HasPermissions(Guid actorId, params string[] permissions)
        {
            var grantedPermissions = await GetPermissions(actorId);
            return !permissions.Except(grantedPermissions).Any(); // Checking if permissions is a subset of grantedPermissions
            // Code from https://stackoverflow.com/a/333034
            // Interesting conversation under this comment : https://stackoverflow.com/a/26697119
        }


        public async Task<IEnumerable<string>> GetPermissions(Guid actorId)
        {
            var client = await _foundationClientFactory.Create();
            var foundationPermissions = await GetFoundationPermissions(client);

            var userApplication = await GetUserApplication(client, actorId);
            if (userApplication == default || !userApplication.RoleAdminId.HasValue)
                return foundationPermissions;

            var rolePermissions = await GetRolePermissions(userApplication.RoleAdminId.Value);
            return foundationPermissions.Concat(rolePermissions.ToList()).ToList();
        }

        private async Task<IEnumerable<string>> GetFoundationPermissions(IFoundationClient client)
        {
            var permissions = await client.Admin.AdminPermissions.GetMany();
            return permissions.Select(permission => permission.Code).ToList();
        }

        private async Task<UserApplicationInfosViewModel> GetUserApplication(IFoundationClient client, Guid userId)
        {
            var userApplications = await client.Admin.UserApplications.GetMany(new UserApplicationFilter()
            {
                UserId = userId
            });

            return userApplications.SingleOrDefault();
        }

        private async Task<IEnumerable<string>> GetRolePermissions(Guid roleAdminId)
        {
            var rolePermissions = await _roleAdminPermissionRepository.GetMany(
                new RoleAdminPermissionsFilter()
                {
                    RoleAdminId = roleAdminId
                }
            );

            return rolePermissions.Select(rp => rp.PermissionAdminCode);
        }
    }
}