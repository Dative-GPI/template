using Foundation.Clients.Abstractions;
using Foundation.Clients.Abstractions.Gateway;
using Foundation.Clients.Abstractions.Shell;

namespace Foundation.Clients.Services
{
    public class GatewayFoundationClient : IGatewayFoundationClient
    {
        private IFoundationClient _root;

        public IGatewayUserFoundationClient Users { get; }
        public IGatewayAccountFoundationClient Accounts { get; }
        public IGatewayTranslationFoundationClient Translations { get; }

        public GatewayFoundationClient(
            IGatewayUserFoundationClient users,
            IGatewayAccountFoundationClient accounts,
            IGatewayTranslationFoundationClient translations
        )
        {
            Users = users;
            Accounts = accounts;
            Translations = translations;
        }

        public void Init(IFoundationClient root)
        {
            this._root = root;

            Users.Init(root);
            Accounts.Init(root);
            Translations.Init(root);
        }
    }
}