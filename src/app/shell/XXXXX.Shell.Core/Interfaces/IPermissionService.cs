using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using XXXXX.Shell.Core.ViewModels;

namespace XXXXX.Shell.Core.Interfaces
{
    public interface IPermissionService
    {
        Task<IEnumerable<string>> GetCurrent(RequestHeaders headers, Guid organisationId);
        Task<IEnumerable<PermissionCategoryViewModel>> GetCategories(RequestHeaders headers, Guid organisationId);
    }
}