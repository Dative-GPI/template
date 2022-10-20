using XXXXX.Admin.Core.Models;

namespace XXXXX.Admin.Core.Abstractions
{
    public interface IRequestContextProvider
    {
        RequestContext Context { get; }
    }
}