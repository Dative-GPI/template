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
    public class GatewayTranslationFoundationClient : IGatewayTranslationFoundationClient
    {
        private FoundationClient _root;
        private ILogger<GatewayTranslationFoundationClient> _logger;

        private HttpClient _client => _root.GatewayClient;

        public GatewayTranslationFoundationClient(ILogger<GatewayTranslationFoundationClient> logger)
        {
            _logger = logger;
        }

        public void Init(IFoundationClient root)
        {
            _root = (FoundationClient)root;
        }

        public async Task<IEnumerable<TranslationViewModel>> GetMany(string languageCode)
        {
            var response = await _client.GetFromJsonAsync<IEnumerable<TranslationViewModel>>($"{TRANSLATIONS_PATH}/{languageCode.ToString()}");

            return response;
        }
    }
}