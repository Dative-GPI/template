using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using XXXXX.Shell.Core.ViewModels;

namespace XXXXX.shell.Core.Interfaces
{
    public interface IDrawerRouteService
    {
        Task<IEnumerable<DrawerRouteInfosViewModel>> GetMany(Guid appId, Guid actorId, DrawerRoutesFilterViewModel filter);
    }
}
