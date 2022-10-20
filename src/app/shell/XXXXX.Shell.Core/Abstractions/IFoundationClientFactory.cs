using System;
using System.Threading.Tasks;

using Foundation.Clients.Abstractions;

namespace XXXXX.Shell.Core.Abstractions
{
    public interface IFoundationClientFactory
    {
        public Task<IFoundationClient> Create();
    }
}