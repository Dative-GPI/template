using System;
using System.Threading.Tasks;

using Foundation.Clients.Abstractions;

namespace XXXXX.Admin.Core.Abstractions
{
    public interface IFoundationClientFactory
    {
        public Task<IFoundationClient> Create();
    }
}