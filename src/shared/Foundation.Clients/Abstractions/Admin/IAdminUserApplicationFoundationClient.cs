using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

using Foundation.Clients.ViewModels;
using Foundation.Clients.ViewModels.Admin;

namespace Foundation.Clients.Abstractions.Admin
{
    public interface IAdminUserApplicationFoundationClient
    {
        void Init(IFoundationClient root);
        Task<UserApplicationDetailsViewModel> Get(Guid userApplicationId);
        Task<IEnumerable<UserApplicationInfosViewModel>> GetMany(UserApplicationFilter filter);
    }
}