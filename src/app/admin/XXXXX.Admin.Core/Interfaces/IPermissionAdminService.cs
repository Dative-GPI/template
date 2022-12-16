using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using XXXXX.Admin.Core.ViewModels;

namespace XXXXX.Admin.Core.Interfaces
{
    public interface IPermissionAdminService
    {
        Task<IEnumerable<PermissionAdminInfosViewModel>> GetMany(Guid appId, Guid actorId, PermissionAdminFilterViewModel filter);
        Task<IEnumerable<string>> GetCurrent(Guid appId, Guid actorId);
    }
}