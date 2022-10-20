using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Foundation.Clients.ViewModels.Shell;

namespace Foundation.Clients.Abstractions.Shell
{
    public interface IShellOrganisationFoundationClient
    {
        Task<OrganisationDetailsViewModel> Get(Guid organisationId);
        Task<IEnumerable<OrganisationInfosViewModel>> GetMany(Guid organisationId, OrganisationFilterViewModel filter);
        void Init(IFoundationClient root);
    }
}