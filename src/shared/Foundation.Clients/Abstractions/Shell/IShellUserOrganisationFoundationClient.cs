using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Foundation.Clients.ViewModels.Shell;

namespace Foundation.Clients.Abstractions.Shell
{
    public interface IShellUserOrganisationFoundationClient
    {
        Task<UserOrganisationDetailsViewModel> Get(Guid organisationId, Guid userOrganisationId);
        Task<IEnumerable<UserOrganisationInfosViewModel>> GetMany(Guid organisationId, UserOrganisationFilterViewModel filter);
        void Init(IFoundationClient root);
    }
}