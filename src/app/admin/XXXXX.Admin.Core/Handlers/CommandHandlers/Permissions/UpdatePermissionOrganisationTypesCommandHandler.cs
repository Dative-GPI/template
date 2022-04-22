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
    public class UpdatePermissionOrganisationTypesCommandHandler : IMiddleware<UpdatePermissionOrganisationTypesCommand>
    {
        private IPermissionOrganisationTypeRepository _permissionOrganisationTypeRepository;

        public UpdatePermissionOrganisationTypesCommandHandler(IPermissionOrganisationTypeRepository permissionOrganisationTypeRepository)
        {
            _permissionOrganisationTypeRepository = permissionOrganisationTypeRepository;
        }

        public async Task HandleAsync(UpdatePermissionOrganisationTypesCommand request, Func<Task> next, CancellationToken cancellationToken)
        {
            var filter = new PermissionOrganisationTypesFilter()
            {
                OrganisationTypeId = request.OrganisationTypeId
            };

            // Get former permissions
            var formerIds = await _permissionOrganisationTypeRepository.GetMany(filter);

            // Remove former permissions
            await _permissionOrganisationTypeRepository.RemoveRange(formerIds.Select(p => p.Id).ToArray());

            // Create the new permissions
            await _permissionOrganisationTypeRepository.CreateRange(request.PermissionsIds.Select(p => new CreatePermissionOrganisationTypes()
            {
                OrganisationTypeId = request.OrganisationTypeId,
                PermissionsId = p
            }));
        }
    }
}