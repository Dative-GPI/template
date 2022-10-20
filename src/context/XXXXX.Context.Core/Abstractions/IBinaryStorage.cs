using System.Threading.Tasks;

namespace XXXXX.Context.Core.Abstractions
{
    public interface IBinaryStorage
    {
        Task Store(string path, byte[] data);
        Task<byte[]> Get(string path);
    }
}