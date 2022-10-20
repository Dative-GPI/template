using Foundation.Clients.Abstractions.Shell;

namespace Foundation.Clients.Abstractions
{
    public interface IShellFoundationClient
    {
        void Init(IFoundationClient root);
        IShellOrganisationFoundationClient Organisations { get; }
        IShellUserOrganisationFoundationClient UserOrganisations { get; }
        IShellPermissionFoundationClient Permissions { get; }
    }
}