using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Bones.Flow;

using XXXXX.Domain.Repositories.Commands;
using XXXXX.Domain.Repositories.Filters;
using XXXXX.Domain.Repositories.Interfaces;

namespace XXXXX.Admin.Core.Handlers
{
    public class UpdateRoleAdminPermissionsCommandHandler : IMiddleware<UpdateRoleAdminPermissionsCommand>
    {
        private IRoleAdminPermissionRepository _roleAdminPermissionRepository;

        public UpdateRoleAdminPermissionsCommandHandler(IRoleAdminPermissionRepository roleAdminPermissionRepository)
        {
            _roleAdminPermissionRepository = roleAdminPermissionRepository;
        }

        public async Task HandleAsync(UpdateRoleAdminPermissionsCommand request, Func<Task> next, CancellationToken cancellationToken)
        {
            var filter = new RoleAdminPermissionsFilter()
            {
                RoleAdminId = request.RoleAdminId
            };

            // Get former permissions
            var formerIds = await _roleAdminPermissionRepository.GetMany(filter);

            // Remove former permissions
            await _roleAdminPermissionRepository.RemoveRange(formerIds.Select(p => p.Id).ToArray());

            // Create the new permissions
            await _roleAdminPermissionRepository.CreateRange(request.PermissionAdminsIds.Select(p => new UpdateRoleAdminPermissions()
            {
                RoleAdminId = request.RoleAdminId,
                PermissionAdminId = p
            }));
        }
    }
}