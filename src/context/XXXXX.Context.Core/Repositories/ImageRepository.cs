using System;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using Bones.Repository.Interfaces;

using XXXXX.Domain.Models;
using XXXXX.Domain.Repositories.Commands;
using XXXXX.Domain.Repositories.Interfaces;

using XXXXX.Context.Core.DTOs;
using XXXXX.Context.Core.Abstractions;

namespace XXXXX.Context.Core.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private DbSet<ImageDTO> _dbSet;
        private IImageHelper _imageHelper;
        private IBinaryStorage _binaryStorage;
        private ILogger<ImageRepository> _logger;

        public ImageRepository(
            ApplicationContext context,
            IImageHelper imageHelper,
            IBinaryStorage binaryStorage,
            ILogger<ImageRepository> logger
        ) {
            _imageHelper = imageHelper;
            _binaryStorage = binaryStorage;
            _dbSet = context.Images;
            _logger = logger;
        }


        public async Task<IEntity<Guid>> Create(CreateImage payload)
        {
            var infos = await _imageHelper.Compute(payload.Data, payload.MaxSize);

            var existing = await _dbSet.FirstOrDefaultAsync(i => i.Path == infos.Path);
            
            // si une image existe déjà avec le même chemin (le même md5) alors pas la peine de la sauvegarder
            if (existing != default)
            {
                return existing;
            }

            await _binaryStorage.Store(infos.Path, infos.Data);
            await _binaryStorage.Store(infos.ThumbnailPath, infos.Thumbnail);

            var imageDTO = _dbSet.Add(new ImageDTO()
            {
                Id = Guid.NewGuid(),
                Label = payload.Label,
                Path = infos.Path,
                ThumbnailPath = infos.ThumbnailPath,
                BlurHash = infos.BlurHash,
                Scope = payload.Scope,
                ApplicationId = payload.ApplicationId,
                OrganisationId = payload.OrganisationId,
                Width = infos.Width,
                Height = infos.Height,
                UserId = payload.UserId,
                Disabled = false
            });

            return imageDTO.Entity;
        }

        public async Task<ImageInfos> GetInfos(Guid imageId)
        {
            var dto = await _dbSet.AsNoTracking()
                .SingleOrDefaultAsync(i => i.Id == imageId);

            if (dto == default)
            {
                return null;
            }

            return new ImageInfos()
            {
                ApplicationId = dto.ApplicationId,
                OrganisationId = dto.OrganisationId,
                UserId = dto.UserId,
                Id = dto.Id,
                Scope = dto.Scope,
            };
        }

        public async Task<byte[]> GetRaw(Guid imageId)
        {
            var dto = await _dbSet.AsNoTracking()
                .SingleOrDefaultAsync(i => i.Id == imageId);

            if (dto == default)
            {
                return null;
            }

            return await _binaryStorage.Get(dto.Path);
        }

        public async Task<byte[]> GetThumbnail(Guid imageId)
        {
            var dto = await _dbSet.AsNoTracking()
                .SingleOrDefaultAsync(i => i.Id == imageId);

            if (dto == default)
            {
                return null;
            }

            return await _binaryStorage.Get(dto.ThumbnailPath);
        }
    }
}