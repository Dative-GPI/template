using System.Threading.Tasks;

using Foundation.Clients.ViewModels;

namespace Foundation.Clients.Abstractions.Gateway
{
    public interface IGatewayAccountFoundationClient
    {
        void Init(IFoundationClient root);
        Task<bool> IsAuthenticated();
    }
}