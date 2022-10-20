using System;
using System.Threading.Tasks;
using Bones.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using XXXXX.Context.Core.DTOs;
using XXXXX.Domain.Models;
using XXXXX.Domain.Repositories.Commands;
using XXXXX.Domain.Repositories.Interfaces;

namespace XXXXX.Context.Core.Repositories
{
    public class ApplicationRepository : IApplicationRepository
    {
        private DbSet<ApplicationDTO> _dbSet;

        public ApplicationRepository(
            ApplicationContext context
        )
        {
            _dbSet = context.Applications;
        }

        public Task<IEntity<Guid>> Create(CreateApplication payload)
        {
            var dto = new ApplicationDTO()
            {
                Id = payload.ApplicationId,
                AdminHost = payload.AdminHost,
                ShellHost = payload.ShellHost,
                AdminJWT = payload.AdminJWT,
                Disabled = false
            };

            _dbSet.Add(dto);

            return Task.FromResult<IEntity<Guid>>(dto);
        }

        public async Task<ApplicationDetails> Get(Guid applicationId)
        {
            var applicationDTO = await _dbSet.AsNoTracking()
                .SingleOrDefaultAsync(a => a.Id == applicationId);

            if (applicationDTO == default)
            {
                return null;
            }

            return new ApplicationDetails()
            {
                Id = applicationDTO.Id,
                AdminHost = applicationDTO.AdminHost,
                ShellHost = applicationDTO.ShellHost,
                AdminJWT = applicationDTO.AdminJWT,
                Disabled = applicationDTO.Disabled
            };
        }

        public async Task<IEntity<Guid>> Update(UpdateApplication payload)
        {
            var dto = await _dbSet.AsNoTracking()
                .SingleOrDefaultAsync(a => a.Id == payload.ApplicationId);

            if (dto == default)
            {
                return null;
            }
            
            dto.AdminHost = payload.AdminHost;
            dto.AdminJWT = payload.AdminJWT;
            dto.ShellHost = payload.ShellHost;
            dto.Disabled = false;

            _dbSet.Update(dto);

            return dto;
        }

        public async Task Remove(Guid applicationId)
        {
            var applicationDTO = await _dbSet.AsNoTracking()
                .SingleOrDefaultAsync(a => a.Id == applicationId);

            applicationDTO.Disabled = true;

            _dbSet.Update(applicationDTO);
        }
    }
}