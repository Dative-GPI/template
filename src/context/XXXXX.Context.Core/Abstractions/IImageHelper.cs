using System.Threading.Tasks;
using XXXXX.Context.Core.Models;

namespace XXXXX.Context.Core.Abstractions
{
    public interface IImageHelper
    {
        Task<Image> Compute(byte[] data, int maxSize);
    }
}