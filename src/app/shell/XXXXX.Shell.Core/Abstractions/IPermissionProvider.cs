using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using XXXXX.Domain.Models;

namespace XXXXX.Shell.Core.Abstractions
{
    public interface IPermissionProvider
    {
        Task<IEnumerable<string>> GetPermissions(Guid organisationId, Guid actorId);
        Task<bool> HasPermissions(Guid organisationId, Guid actorId, params string[] permissions);
    }
}