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
    public class RolePermissionRepository : IRolePermissionRepository
    {
        private DbSet<RolePermissionDTO> _dbSet;

        public RolePermissionRepository(ApplicationContext context)
        {
            _dbSet = context.RolePermissions;
        }

        public async Task<IEnumerable<RolePermission>> GetMany(RolePermissionsFilter filter)
        {
            var query = _dbSet.Include(p => p.Permission).AsQueryable();
                
            query = query.Where(p => p.RoleId == filter.RoleId);

            IEnumerable<RolePermissionDTO> dtos = await query.AsNoTracking().ToListAsync();

            return dtos.Select(rolePermissionDTO => new RolePermission()
            {
                Id = rolePermissionDTO.Id,
                PermissionId = rolePermissionDTO.PermissionId,
                PermissionCode = rolePermissionDTO.Permission.Code
            });
        }

        public Task RemoveRange(Guid[] permissionsIds)
        {
            _dbSet.RemoveRange(permissionsIds.Select(id => new RolePermissionDTO()
            {
                Id = id
            }));

            return Task.CompletedTask;
        }

        public Task CreateRange(IEnumerable<UpdateRolePermissions> payload)
        {
            _dbSet.AddRange(payload.Select(p => new RolePermissionDTO()
            {
                Id = Guid.NewGuid(),
                RoleId = p.RoleId,
                PermissionId = p.PermissionsId,
                Disabled = false
            }));

            return Task.CompletedTask;
        }

    }
}