using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using XXXXX.Shell.Core.ViewModels;

namespace XXXXX.Shell.Core.Interfaces {
    public interface IRolePermissionService {
        Task<IEnumerable<PermissionInfosViewModel>> GetMany(RequestHeaders headers, Guid organisationId, Guid roleId);
        Task Update(RequestHeaders headers, Guid organisationId, Guid roleId, List<Guid> payload);
    }
}