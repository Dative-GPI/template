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
    public class ShellUserOrganisationFoundationClient : IShellUserOrganisationFoundationClient
    {
        private FoundationClient _root;
        private ILogger<ShellUserOrganisationFoundationClient> _logger;

        private HttpClient _client => _root.ShellClient;

        public ShellUserOrganisationFoundationClient(ILogger<ShellUserOrganisationFoundationClient> logger)
        {
            _logger = logger;
        }

        public void Init(IFoundationClient root)
        {
            _root = (FoundationClient)root;
        }

        public async Task<IEnumerable<UserOrganisationInfosViewModel>> GetMany(Guid organisationId, UserOrganisationFilterViewModel filter)
        {
            _client.DefaultRequestHeaders.Set("X-Organisation-Id", organisationId.ToString());
            
            Url url = USER_ORGANISATIONS_PATH.SetQueryParams(filter);

            var userOrganisations = await _client.GetFromJsonAsync<IEnumerable<UserOrganisationInfosViewModel>>(url.ToUri());

            _logger.LogInformation("Receiving {count} user-organisations", userOrganisations.Count());

            return userOrganisations;
        }

        public async Task<UserOrganisationDetailsViewModel> Get(Guid organisationId, Guid userOrganisationId)
        {
            _client.DefaultRequestHeaders.Set("X-Organisation-Id", organisationId.ToString());
            
            var userOrganisation = await _client.GetFromJsonAsync<UserOrganisationDetailsViewModel>($"{USER_ORGANISATIONS_PATH}/{userOrganisationId}");

            _logger.LogInformation("Receiving user-organisation {uoId}", userOrganisationId);

            return userOrganisation;
        }
    }
}