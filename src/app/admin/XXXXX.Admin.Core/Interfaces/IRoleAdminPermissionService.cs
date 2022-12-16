using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using XXXXX.Admin.Core.ViewModels;

namespace XXXXX.Admin.Core.Interfaces
{
    public interface IRoleAdminPermissionService
    {
        Task<IEnumerable<PermissionAdminInfosViewModel>> GetMany(Guid appId, Guid actorId, Guid roleAdminId);
        Task Update(Guid appId, Guid actorId, Guid roleAdminId, List<Guid> payload);
    }
}