using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.Extensions.Logging;
using Flurl;

using Foundation.Clients.Abstractions;
using Foundation.Clients.Abstractions.Shell;
using Foundation.Clients.ViewModels.Shell;

using static Foundation.Clients.Services.ShellFoundationRoutes;
using Foundation.Clients.Extensions;

namespace Foundation.Clients.Services
{
    public class ShellPermissionFoundationClient : IShellPermissionFoundationClient
    {
        private FoundationClient _root;
        private ILogger<ShellPermissionFoundationClient> _logger;

        private HttpClient _client => _root.ShellClient;

        public ShellPermissionFoundationClient(ILogger<ShellPermissionFoundationClient> logger)
        {
            _logger = logger;
        }

        public void Init(IFoundationClient root)
        {
            _root = (FoundationClient)root;
        }

        public async Task<IEnumerable<PermissionInfosViewModel>> GetMany(Guid organisationId)
        {
            _client.DefaultRequestHeaders.Set("X-Organisation-Id", organisationId.ToString());
            
            Url url = PERMISSIONS_PATH;

            var permissions = await _client.GetFromJsonAsync<List<PermissionInfosViewModel>>(url.ToUri());

            _logger.LogInformation("Receiving {count} permissions", permissions.Count());

            return permissions;
        }
    }
}