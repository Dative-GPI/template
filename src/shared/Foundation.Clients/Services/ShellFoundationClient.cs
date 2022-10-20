using Foundation.Clients.Abstractions;
using Foundation.Clients.Abstractions.Shell;

namespace Foundation.Clients.Services
{
    public class ShellFoundationClient : IShellFoundationClient
    {
        private IFoundationClient _root;

        public IShellOrganisationFoundationClient Organisations { get; }
        public IShellUserOrganisationFoundationClient UserOrganisations { get; }
        public IShellPermissionFoundationClient Permissions { get; }

        public ShellFoundationClient(
            IShellOrganisationFoundationClient organisations,
            IShellUserOrganisationFoundationClient userOrganisations,
            IShellPermissionFoundationClient permissions
        )
        {
            Organisations = organisations;
            UserOrganisations = userOrganisations;
            Permissions = permissions;
        }

        public void Init(IFoundationClient root)
        {
            this._root = root;

            Organisations.Init(root);
            UserOrganisations.Init(root);
            Permissions.Init(root);
        }
    }
}