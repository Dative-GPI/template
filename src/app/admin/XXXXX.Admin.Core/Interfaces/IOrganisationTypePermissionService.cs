using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using XXXXX.Admin.Core.ViewModels;

namespace XXXXX.Admin.Core.Interfaces
{
    public interface IOrganisationTypePermissionService
    {
        Task<IEnumerable<PermissionInfosViewModel>> GetMany(Guid appId, Guid actorId, Guid organisationTypeId);
        Task Update(Guid appId, Guid actorId, Guid organisationTypeId, List<Guid> payload);
    }
}