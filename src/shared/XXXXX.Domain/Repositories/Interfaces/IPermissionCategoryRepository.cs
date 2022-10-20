using System.Collections.Generic;
using System.Threading.Tasks;

using XXXXX.Domain.Models;

namespace XXXXX.Domain.Repositories.Interfaces
{
    public interface IPermissionCategoryRepository
    {
        Task<IEnumerable<PermissionCategory>> GetMany();
    }
}