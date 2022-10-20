using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.Extensions.Logging;

using Foundation.Clients.Abstractions;
using Foundation.Clients.Abstractions.Gateway;

using Foundation.Clients.ViewModels;

using static Foundation.Clients.Services.GatewayFoundationRoutes;

namespace Foundation.Clients.Services
{
    public class GatewayAccountFoundationClient : IGatewayAccountFoundationClient
    {
        private FoundationClient _root;
        private ILogger<GatewayAccountFoundationClient> _logger;

        private HttpClient _client => _root.GatewayClient;

        public GatewayAccountFoundationClient(ILogger<GatewayAccountFoundationClient> logger)
        {
            _logger = logger;
        }

        public void Init(IFoundationClient root)
        {
            _root = (FoundationClient)root;
        }

        public async Task<bool> IsAuthenticated()
        {
            var response = await _client.GetAsync($"{ACCOUNTS_PATH}/logged-in");

            return response.IsSuccessStatusCode;
        }
    }
}