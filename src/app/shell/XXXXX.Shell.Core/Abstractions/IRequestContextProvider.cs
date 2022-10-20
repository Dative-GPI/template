using System.Threading.Tasks;

using XXXXX.Shell.Core.Models;

namespace XXXXX.Shell.Core.Abstractions
{
    public interface IRequestContextProvider
    {
        RequestContext Context { get; }
    }
}