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
    public class UpdateOrganisationTypePermissionsCommandHandler : IMiddleware<UpdateOrganisationTypePermissionsCommand>
    {
        private IOrganisationTypePermissionRepository _organisationTypePermissionRepository;

        public UpdateOrganisationTypePermissionsCommandHandler(IOrganisationTypePermissionRepository organisationTypePermissionRepository)
        {
            _organisationTypePermissionRepository = organisationTypePermissionRepository;
        }

        public async Task HandleAsync(UpdateOrganisationTypePermissionsCommand request, Func<Task> next, CancellationToken cancellationToken)
        {
            var filter = new OrganisationTypePermissionsFilter()
            {
                OrganisationTypeId = request.OrganisationTypeId
            };

            // Get former permissions
            var formerIds = await _organisationTypePermissionRepository.GetMany(filter);

            // Remove former permissions
            await _organisationTypePermissionRepository.RemoveRange(formerIds.Select(p => p.Id).ToArray());

            // Create the new permissions
            await _organisationTypePermissionRepository.CreateRange(request.PermissionsIds.Select(p => new UpdateOrganisationTypePermissions()
            {
                OrganisationTypeId = request.OrganisationTypeId,
                PermissionsId = p
            }));
        }
    }
}