using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using XXXXX.Admin.Core.ViewModels;

namespace XXXXX.Admin.Core.Interfaces
{
    public interface IPermissionAdminCategoryService
    {
        Task<IEnumerable<PermissionAdminCategoryViewModel>> GetMany(Guid appId, Guid actorId);
    }
}