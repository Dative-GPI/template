using System;
using System.Net.Http;

using Foundation.Clients.Abstractions;

namespace Foundation.Clients.Services
{
    public class FoundationClient : IFoundationClient
    {
        public HttpClient AdminClient { get; }
        public HttpClient ShellClient { get; }
        public HttpClient GatewayClient { get; }

        public IAdminFoundationClient Admin { get; }
        public IShellFoundationClient Shell { get; }
        public IGatewayFoundationClient Gateway { get; }

        public FoundationClient(
            HttpClient adminClient,
            HttpClient shellClient,
            HttpClient gatewayClient,
            IAdminFoundationClient adminFoundationClient,
            IShellFoundationClient shellFoundationClient,
            IGatewayFoundationClient gatewayFoundationClient)
        {
            AdminClient = adminClient;
            ShellClient = shellClient;
            GatewayClient = gatewayClient;

            Admin = adminFoundationClient;
            Shell = shellFoundationClient;
            Gateway = gatewayFoundationClient;
        }

        public void Init(string adminHost, string shellHost, string languageCode, string jwt = null, string adminJwt = null)
        {
            AdminClient.BaseAddress = new Uri($"https://{adminHost}");
            ShellClient.BaseAddress = new Uri($"https://{shellHost}");
            GatewayClient.BaseAddress = new Uri($"https://{shellHost}");

            if (!String.IsNullOrWhiteSpace(jwt))
            {
                ShellClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {jwt}");
                GatewayClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {jwt}");
            }
            if (!String.IsNullOrWhiteSpace(adminJwt))
            {
                AdminClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {adminJwt}");
            }

            if (!string.IsNullOrEmpty(languageCode))
            {
                AdminClient.DefaultRequestHeaders.Add("Accept-Language", languageCode);
                ShellClient.DefaultRequestHeaders.Add("Accept-Language", languageCode);
                GatewayClient.DefaultRequestHeaders.Add("Accept-Language", languageCode);
            }

            Admin.Init(this);
            Shell.Init(this);
            Gateway.Init(this);
        }
    }
}