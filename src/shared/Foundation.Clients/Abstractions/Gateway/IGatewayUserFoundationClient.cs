using System.Threading.Tasks;

using Foundation.Clients.ViewModels;

namespace Foundation.Clients.Abstractions.Gateway
{
    public interface IGatewayUserFoundationClient
    {
        void Init(IFoundationClient root);
        Task<UserInfosViewModel> GetCurrentUser();
    }
}