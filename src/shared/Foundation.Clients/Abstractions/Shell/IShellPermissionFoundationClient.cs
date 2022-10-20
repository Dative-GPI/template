using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Foundation.Clients.ViewModels.Shell;

namespace Foundation.Clients.Abstractions.Shell
{
    public interface IShellPermissionFoundationClient
    {
        void Init(IFoundationClient root);
        Task<IEnumerable<PermissionInfosViewModel>> GetMany(Guid organisationId);
    }
}