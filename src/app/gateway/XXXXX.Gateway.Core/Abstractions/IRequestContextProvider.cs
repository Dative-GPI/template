using XXXXX.Gateway.Core.Models;

namespace XXXXX.Gateway.Core.Abstractions
{
    public interface IRequestContextProvider
    {
        RequestContext Context { get; }
    }
}