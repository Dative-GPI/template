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
    public class OrganisationTypePermissionRepository : IOrganisationTypePermissionRepository
    {
        private DbSet<OrganisationTypePermissionDTO> _dbSet;

        public OrganisationTypePermissionRepository(ApplicationContext context)
        {
            _dbSet = context.OrganisationTypePermissions;
        }

        public async Task<IEnumerable<OrganisationTypePermission>> GetMany(OrganisationTypePermissionsFilter filter)
        {
            var query = _dbSet.Include(p => p.Permission).AsQueryable();
                
            query = query.Where(p => p.OrganisationTypeId == filter.OrganisationTypeId);

            IEnumerable<OrganisationTypePermissionDTO> dtos = await query.AsNoTracking().ToListAsync();

            return dtos.Select(organisationTypePermissionDTO => new OrganisationTypePermission()
            {
                Id = organisationTypePermissionDTO.Id,
                PermissionId = organisationTypePermissionDTO.PermissionId,
                PermissionCode = organisationTypePermissionDTO.Permission.Code
            });
        }

        public Task RemoveRange(Guid[] permissionsIds)
        {
            _dbSet.RemoveRange(permissionsIds.Select(id => new OrganisationTypePermissionDTO()
            {
                Id = id
            }));

            return Task.CompletedTask;
        }

        public Task CreateRange(IEnumerable<UpdateOrganisationTypePermissions> payload)
        {
            _dbSet.AddRange(payload.Select(p => new OrganisationTypePermissionDTO()
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