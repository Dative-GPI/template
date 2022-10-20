using System.Collections.Generic;
using System.Threading.Tasks;

using Foundation.Clients.Abstractions;
using Foundation.Clients.Abstractions.Admin;

namespace Foundation.Clients.Services
{
    public class AdminFoundationClient : IAdminFoundationClient
    {
        private IFoundationClient _root;
        public IAdminUserApplicationFoundationClient UserApplications { get; }
        public IAdminPermissionFoundationClient AdminPermissions { get; }

        public AdminFoundationClient(
            IAdminUserApplicationFoundationClient userApplication,
            IAdminPermissionFoundationClient adminPermissions
        )
        {
            UserApplications = userApplication;
            AdminPermissions = adminPermissions;
        }


        public void Init(IFoundationClient root)
        {
            this._root = root;

            UserApplications.Init(root);
            AdminPermissions.Init(root);
        }
    }
}