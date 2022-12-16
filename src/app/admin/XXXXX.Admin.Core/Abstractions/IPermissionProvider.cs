using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace XXXXX.Admin.Core.Abstractions
{
    public interface IPermissionProvider
    {
        Task<IEnumerable<string>> GetPermissions(Guid actorId);
        Task<bool> HasPermissions(Guid actorId, params string[] permissions);
    }
}