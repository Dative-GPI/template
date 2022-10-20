using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Foundation.Clients.Abstractions;
using Foundation.Clients.ViewModels.Shell;
using XXXXX.Domain.Repositories.Filters;
using XXXXX.Domain.Repositories.Interfaces;
using XXXXX.Shell.Core.Abstractions;

namespace XXXXX.Shell.Core.Tools
{
    public class PermissionProvider : IPermissionProvider
    {
        private readonly IFoundationClientFactory _foundationClientFactory;
        private readonly IRolePermissionRepository _rolePermissionRepository;
        private readonly IOrganisationTypePermissionRepository _organisationTypePermissionRepository;

        public PermissionProvider(
            IFoundationClientFactory foundationClientFactory,
            IRolePermissionRepository rolePermissionRepository,
            IOrganisationTypePermissionRepository organisationTypePermissionRepository
        )
        {
            _foundationClientFactory = foundationClientFactory;
            _rolePermissionRepository = rolePermissionRepository;
            _organisationTypePermissionRepository = organisationTypePermissionRepository;
        }


        public async Task<bool> HasPermissions(Guid organisationId, Guid actorId, params string[] permissions)
        {
            var grantedPermissions = await GetPermissions(organisationId, actorId);
            return !permissions.Except(grantedPermissions).Any(); // Checking if permissions is a subset of grantedPermissions
            // Code from https://stackoverflow.com/a/333034
            // Interesting conversation under this comment : https://stackoverflow.com/a/26697119
        }


        public async Task<IEnumerable<string>> GetPermissions(Guid organisationId, Guid actorId)
        {
            var client = await _foundationClientFactory.Create();
            var foundationPermissions = await GetFoundationPermissions(client, organisationId);

            var organisation = await client.Shell.Organisations.Get(organisationId);
            var organisationTypePermissions = await GetOrganisationTypePermissions(organisation.OrganisationTypeId);

            if (organisation.AdminId == actorId)
                return foundationPermissions.Concat(organisationTypePermissions).ToList();

            var userOrganisation = await GetUserOrganisation(client, organisationId, actorId);
            if (userOrganisation == default || !userOrganisation.RoleId.HasValue)
                return foundationPermissions;

            var rolePermissions = await GetRolePermissions(userOrganisation.RoleId.Value);

            return foundationPermissions.Concat(
                rolePermissions.Intersect(organisationTypePermissions).ToList()
            ).ToList();
            // use of intersect to make sure that the permissions of a role is a subset of
            // the permissions of an organisationType 
        }

        private async Task<IEnumerable<string>> GetFoundationPermissions(IFoundationClient client, Guid organisationId)
        {
            var permissions = await client.Shell.Permissions.GetMany(organisationId);
            return permissions.Select(permission => permission.Code).ToList();
        }

        private async Task<IEnumerable<string>> GetOrganisationTypePermissions(Guid organisationTypeId)
        {
            var organisationTypePermissions = await _organisationTypePermissionRepository.GetMany(
                new OrganisationTypePermissionsFilter()
                {
                    OrganisationTypeId = organisationTypeId
                }
            );

            return organisationTypePermissions.Select(otp => otp.PermissionCode).ToList();
        }

        private async Task<IEnumerable<string>> GetRolePermissions(Guid roleId)
        {
            var rolePermissions = await _rolePermissionRepository.GetMany(
                new RolePermissionsFilter()
                {
                    RoleId = roleId
                }
            );

            return rolePermissions.Select(rp => rp.PermissionCode).ToList();
        }

        private async Task<UserOrganisationInfosViewModel> GetUserOrganisation(IFoundationClient client, Guid organisationId, Guid userId)
        {
            var userOrganisations = await client.Shell.UserOrganisations.GetMany(
                organisationId,
                new UserOrganisationFilterViewModel()
                {
                    UserId = userId
                }
            );
            return userOrganisations.FirstOrDefault();
        }
    }
}