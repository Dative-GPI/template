using System;
using System.Threading.Tasks;
using XXXXX.Gateway.Core.ViewModels;

namespace XXXXX.Gateway.Core.Interfaces
{
    public interface IApplicationService
    {
        Task<ApplicationDetailsViewModel> Create(CreateApplicationViewModel payload);
        Task Remove(Guid actorId, Guid applicationId);
    }
}