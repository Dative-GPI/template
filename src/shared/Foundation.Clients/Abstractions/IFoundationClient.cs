using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Foundation.Clients.Abstractions
{
    public interface IFoundationClient
    {
        void Init(string adminHost, string shellHost, string languageCode, string jwt = null, string adminJwt = null);
        IAdminFoundationClient Admin { get; }
        IShellFoundationClient Shell { get; }
        IGatewayFoundationClient Gateway { get; }
    }
}