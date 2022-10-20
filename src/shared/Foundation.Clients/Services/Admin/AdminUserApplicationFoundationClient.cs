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
    public class AdminUserApplicationFoundationClient : IAdminUserApplicationFoundationClient
    {
        private FoundationClient _root;

        private HttpClient _client => _root.AdminClient;


        public void Init(IFoundationClient root)
        {
            _root = (FoundationClient)root;
        }

        public async Task<UserApplicationDetailsViewModel> Get(Guid userApplicationId)
        {
            Url url = $"{USER_APPLICATIONS_PATH}/{userApplicationId}";

            var userApplication = await _client.GetFromJsonAsync<UserApplicationDetailsViewModel>(url.ToUri());

            return userApplication;
        }

        public async Task<IEnumerable<UserApplicationInfosViewModel>> GetMany(UserApplicationFilter filter)
        {
            Url url = USER_APPLICATIONS_PATH.SetQueryParams(filter);

            var userApplications = await _client.GetFromJsonAsync<List<UserApplicationInfosViewModel>>(url.ToUri());

            return userApplications;
        }
    }
}