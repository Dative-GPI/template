using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Bones.Flow;

using XXXXX.Domain.Models;
using XXXXX.Domain.Repositories.Filters;
using XXXXX.Domain.Repositories.Interfaces;

namespace XXXXX.Admin.Core.Handlers
{
    public class PermissionAdminsQueryHandler : IMiddleware<PermissionAdminsQuery, IEnumerable<PermissionAdminInfos>>
    {
        private IPermissionAdminRepository _permissionAdminRepository;
        
        public PermissionAdminsQueryHandler(IPermissionAdminRepository permissionAdminRepository)
        {
            _permissionAdminRepository = permissionAdminRepository;
        }

        public async Task<IEnumerable<PermissionAdminInfos>> HandleAsync(PermissionAdminsQuery request, Func<Task<IEnumerable<PermissionAdminInfos>>> next, CancellationToken cancellationToken)
        {
            var filter = new PermissionAdminFilter()
            {
                Search = request.Search,
                PermissionAdminIds = request.PermissionAdminIds,
                RoleAdminId = request.RoleAdminId
            };

            return await _permissionAdminRepository.GetMany(filter);
        }
    }
}