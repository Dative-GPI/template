using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

using Flurl;

using Foundation.Clients.Abstractions;
using Foundation.Clients.Abstractions.Admin;
using Foundation.Clients.ViewModels.Admin;

using static Foundation.Clients.Services.AdminFoundationRoutes;

namespace Foundation.Clients.Services
{
    public class AdminPermissionFoundationClient : IAdminPermissionFoundationClient
    {
        private FoundationClient _root;

        private HttpClient _client => _root.AdminClient;


        public void Init(IFoundationClient root)
        {
            _root = (FoundationClient)root;
        }

        public async Task<IEnumerable<PermissionAdminInfosViewModel>> GetMany()
        {
            Url url = CURRENT_PERMISSIONS_ADMIN_PATH;

            var adminPermissions = await _client.GetFromJsonAsync<List<PermissionAdminInfosViewModel>>(url.ToUri());

            return adminPermissions;
        }
    }
}