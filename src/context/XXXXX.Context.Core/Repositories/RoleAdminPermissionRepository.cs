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
    public class RoleAdminPermissionRepository : IRoleAdminPermissionRepository
    {
        private DbSet<RoleAdminPermissionDTO> _dbSet;

        public RoleAdminPermissionRepository(ApplicationContext context)
        {
            _dbSet = context.RoleAdminPermissions;
        }

        public async Task<IEnumerable<RoleAdminPermission>> GetMany(RoleAdminPermissionsFilter filter)
        {
            var query = _dbSet.Include(p => p.PermissionAdmin).AsQueryable();
                
            query = query.Where(p => p.RoleAdminId == filter.RoleAdminId);

            IEnumerable<RoleAdminPermissionDTO> dtos = await query.AsNoTracking().ToListAsync();

            return dtos.Select(rolePermissionDTO => new RoleAdminPermission()
            {
                Id = rolePermissionDTO.Id,
                PermissionAdminId = rolePermissionDTO.PermissionAdminId,
                PermissionAdminCode = rolePermissionDTO.PermissionAdmin.Code
            }).ToList();
        }

        public Task RemoveRange(Guid[] permissionsIds)
        {
            _dbSet.RemoveRange(permissionsIds.Select(id => new RoleAdminPermissionDTO()
            {
                Id = id
            }));

            return Task.CompletedTask;
        }

        public Task CreateRange(IEnumerable<UpdateRoleAdminPermissions> payload)
        {
            _dbSet.AddRange(payload.Select(p => new RoleAdminPermissionDTO()
            {
                Id = Guid.NewGuid(),
                RoleAdminId = p.RoleAdminId,
                PermissionAdminId = p.PermissionAdminId,
                Disabled = false
            }));

            return Task.CompletedTask;
        }

    }
}