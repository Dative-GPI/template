using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Bones.Repository.Interfaces;

using XXXXX.Domain.Models;
using XXXXX.Domain.Repositories.Commands;

namespace XXXXX.Domain.Repositories.Interfaces
{
    public interface IImageRepository
    {
        Task<byte[]> GetRaw(Guid imageId);
        Task<byte[]> GetThumbnail(Guid imageId);
        Task<ImageInfos> GetInfos(Guid imageId);
        Task<IEntity<Guid>> Create(CreateImage payload);
    }
}