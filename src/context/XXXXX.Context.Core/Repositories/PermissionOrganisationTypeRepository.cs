using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using XXXXX.Context.Core.DTOs;

using XXXXX.Domain.Models;
using XXXXX.Domain.Repositories.Commands;
using XXXXX.Domain.Repositories.Filters;
using XXXXX.Domain.Repositories.Interfaces;

namespace XXXXX.Context.Core.Repositories
{
    public class PermissionOrganisationTypeRepository : IPermissionOrganisationTypeRepository
    {
        private DbSet<PermissionOrganisationTypeDTO> _dbSet;

        public PermissionOrganisationTypeRepository(ApplicationContext context)
        {
            _dbSet = context.PermissionOrganisationTypes;
        }

        public async Task<IEnumerable<PermissionOrganisationType>> GetMany(PermissionOrganisationTypesFilter filter)
        {
            var query = _dbSet.Include(p => p.Permission).AsQueryable();
                
            query = query.Where(p => p.OrganisationTypeId == filter.OrganisationTypeId);

            IEnumerable<PermissionOrganisationTypeDTO> dtos = await query.AsNoTracking().ToListAsync();

            return dtos.Select(permissionOrganisationTypeDTO => new PermissionOrganisationType()
            {
                Id = permissionOrganisationTypeDTO.Id,
                PermissionId = permissionOrganisationTypeDTO.PermissionId,
                PermissionCode = permissionOrganisationTypeDTO.Permission.Code
            });
        }

        public Task RemoveRange(Guid[] permissionsIds)
        {
            _dbSet.RemoveRange(permissionsIds.Select(id => new PermissionOrganisationTypeDTO()
            {
                Id = id
            }));

            return Task.CompletedTask;
        }

        public Task CreateRange(IEnumerable<CreatePermissionOrganisationTypes> payload)
        {
            _dbSet.AddRange(payload.Select(p => new PermissionOrganisationTypeDTO()
            {
                Id = Guid.NewGuid(),
                OrganisationTypeId = p.OrganisationTypeId,
                PermissionId = p.PermissionsId,
                Disabled = false
            }));

            return Task.CompletedTask;
        }
    }
}