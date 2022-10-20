using Foundation.Clients.Abstractions.Gateway;

namespace Foundation.Clients.Abstractions
{
    public interface IGatewayFoundationClient
    {
        void Init(IFoundationClient root);
        IGatewayUserFoundationClient Users { get; }
        IGatewayAccountFoundationClient Accounts { get; }
        IGatewayTranslationFoundationClient Translations { get; }
    }
}