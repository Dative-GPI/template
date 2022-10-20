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
    public class GatewayUserFoundationClient : IGatewayUserFoundationClient
    {
        private FoundationClient _root;
        private ILogger<GatewayUserFoundationClient> _logger;

        private HttpClient _client => _root.GatewayClient;

        public GatewayUserFoundationClient(ILogger<GatewayUserFoundationClient> logger)
        {
            _logger = logger;
        }

        public void Init(IFoundationClient root)
        {
            _root = (FoundationClient)root;
        }

        public async Task<UserInfosViewModel> GetCurrentUser()
        {
            var user = await _client.GetFromJsonAsync<UserInfosViewModel>($"{USERS_PATH}/current");

            return user;
        }
    }
}