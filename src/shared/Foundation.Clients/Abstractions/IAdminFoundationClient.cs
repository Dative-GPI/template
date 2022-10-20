using Foundation.Clients.Abstractions.Admin;

namespace Foundation.Clients.Abstractions
{
    public interface IAdminFoundationClient
    {
        void Init(IFoundationClient root);

        IAdminUserApplicationFoundationClient UserApplications { get; }
        IAdminPermissionFoundationClient AdminPermissions { get; }
    }
}