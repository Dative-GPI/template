using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XXXXX.Admin.Core.ViewModels;

namespace XXXXX.Admin.Core.Interfaces
{
    public interface IPermissionService
    {
        Task<IEnumerable<PermissionInfosViewModel>> GetMany(Guid appId, Guid actorId, PermissionsFilterViewModel filter);
        Task<IEnumerable<PermissionCategoryViewModel>> GetCategories(Guid appId, Guid actorId);
    }
}