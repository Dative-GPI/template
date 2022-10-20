using System;
using System.Threading.Tasks;

using XXXXX.Gateway.Core.ViewModels;

namespace XXXXX.Gateway.Core.Interfaces
{
    public interface IImageService
    {
        Task<byte[]> GetRaw(Guid id);
        Task<byte[]> GetThumbnail(Guid id);
    }
}