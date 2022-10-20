using System;
using System.Threading.Tasks;
using Foundation.Clients.Abstractions;

namespace XXXXX.Gateway.Core.Abstractions
{
    public interface IFoundationClientFactory
    {
        Task<IFoundationClient> Create(Guid applicationId, string languageCode, string jwt);
        Task<IFoundationClient> Create();
    }
}