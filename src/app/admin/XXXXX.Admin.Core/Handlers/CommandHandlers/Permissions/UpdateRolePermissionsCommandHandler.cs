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
    public class UpdateRolePermissionsCommandHandler : IMiddleware<UpdateRolePermissionsCommand>
    {
        private IRolePermissionRepository _rolePermissionRepository;

        public UpdateRolePermissionsCommandHandler(IRolePermissionRepository rolePermissionRepository)
        {
            _rolePermissionRepository = rolePermissionRepository;
        }

        public async Task HandleAsync(UpdateRolePermissionsCommand request, Func<Task> next, CancellationToken cancellationToken)
        {
            var filter = new RolePermissionsFilter()
            {
                RoleId = request.RoleId
            };

            // Get former permissions
            var formerIds = await _rolePermissionRepository.GetMany(filter);

            // Remove former permissions
            await _rolePermissionRepository.RemoveRange(formerIds.Select(p => p.Id).ToArray());

            // Create the new permissions
            await _rolePermissionRepository.CreateRange(request.PermissionsIds.Select(p => new UpdateRolePermissions()
            {
                RoleId = request.RoleId,
                PermissionsId = p
            }));
        }
    }
}