using System.Collections.Generic;
using System.Threading.Tasks;

using XXXXX.Domain.Models;
using XXXXX.Domain.Repositories.Filters;

namespace XXXXX.Domain.Repositories.Interfaces
{
    public interface IPermissionRepository
    {
        Task<IEnumerable<PermissionInfos>> GetMany(PermissionsFilter filter);
        Task<IEnumerable<PermissionCategory>> GetCategories();
    }
}