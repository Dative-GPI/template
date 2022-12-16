using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Bones.Flow;
using XXXXX.Shell.Core.Abstractions;

namespace XXXXX.Shell.Core.Handlers
{
    public class PermissionsMiddleware : IMiddleware<ICoreRequest>
    {
        public IPermissionProvider _permissionProvider;

        public PermissionsMiddleware(IPermissionProvider permissionProvider)
        {
            _permissionProvider = permissionProvider;
        }

        public async Task HandleAsync(ICoreRequest request, Func<Task> next, CancellationToken cancellationToken)
        {
            var hasPermission = await _permissionProvider.HasPermissions(
                request.OrganisationId,
                request.ActorId,
                request.Authorizations.ToArray()
            );

            if (!hasPermission)
                throw new UnauthorizedAccessException();

            await next();
        }
    }
}