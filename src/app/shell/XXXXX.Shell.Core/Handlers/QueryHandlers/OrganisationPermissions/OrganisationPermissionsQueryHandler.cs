using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Bones.Flow;
using XXXXX.Domain.Abstractions;
using XXXXX.Domain.Models;
using XXXXX.Domain.Repositories.Filters;
using XXXXX.Domain.Repositories.Interfaces;
using XXXXX.Shell.Core.Abstractions;

namespace XXXXX.Shell.Core.Handlers
{
    public class OrganisationPermissionsQueryHandler : IMiddleware<OrganisationPermissionsQuery, IEnumerable<PermissionInfos>>
    {
        private readonly IFoundationClientFactory _clientFactory;
        private readonly IPermissionRepository _permissionRepository;
        private readonly IRequestContextProvider _requestContextProvider;

        public OrganisationPermissionsQueryHandler(
            IFoundationClientFactory clientFactory,
            IPermissionRepository permissionRepository,
            IRequestContextProvider requestContextProvider
        )
        {
            _clientFactory = clientFactory;
            _permissionRepository = permissionRepository;
            _requestContextProvider = requestContextProvider;
        }

        public async Task<IEnumerable<PermissionInfos>> HandleAsync(OrganisationPermissionsQuery request, Func<Task<IEnumerable<PermissionInfos>>> next, CancellationToken cancellationToken)
        {
            var client = await _clientFactory.CreateFromRequestContext(_requestContextProvider.Context);

            var organisation = await client.Shell.Organisations.Get(request.OrganisationId);
            var permissions = await _permissionRepository.GetMany(new PermissionsFilter() {
                OrganisationTypeId = organisation.OrganisationTypeId
            });

            return permissions;
        }
    }
}