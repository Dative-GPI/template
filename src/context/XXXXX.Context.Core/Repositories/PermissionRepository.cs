using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using XXXXX.Context.Core.DTOs;

using XXXXX.Domain.Models;
using XXXXX.Domain.Repositories.Filters;
using XXXXX.Domain.Repositories.Interfaces;

namespace XXXXX.Context.Core.Repositories
{
    public class PermissionRepository : IPermissionRepository
    {
        private DbSet<PermissionDTO> _dbSet;

        public PermissionRepository(ApplicationContext context)
        {
            _dbSet = context.Permissions;
        }

        public async Task<IEnumerable<PermissionInfos>> GetMany(PermissionsFilter filter)
        {
            var query = _dbSet
                .Include(p => p.OrganisationTypePermissions)
                .Include(p => p.RolePermissions)
                .AsQueryable();

            if (filter.PermissionIds != null && filter.PermissionIds.Any())
            {
                query = query.Where(p => filter.PermissionIds.Contains(p.Id));
            }

            if (!String.IsNullOrWhiteSpace(filter.Search))
            {
                string caseInsensitiveSearch = filter.Search.ToLowerInvariant();
                query = query.Where(p => 
                    p.LabelDefault.ToLowerInvariant().Contains(caseInsensitiveSearch) ||
                    p.Code.ToLowerInvariant().Contains(caseInsensitiveSearch)    
                );
            }

            if (filter.OrganisationTypeId.HasValue)
            {
                query = query.Where(
                    p => p.OrganisationTypePermissions.Any(
                        otp => otp.OrganisationTypeId == filter.OrganisationTypeId.Value
                    )
                );
            }

            if (filter.RoleId.HasValue)
            {
                query = query.Where(
                    p => p.RolePermissions
                        .Any(rp => rp.RoleId == filter.RoleId.Value)
                );
            }

            IEnumerable<PermissionDTO> dtos = await query.AsNoTracking().ToListAsync();

            return dtos.Select(permissionDTO => new PermissionInfos()
            {
                Id = permissionDTO.Id,
                Code = permissionDTO.Code,
                Label = permissionDTO.LabelDefault,
                Translations = permissionDTO.Translations?.Select(t => new TranslationPermission()
                {
                    LanguageCode = t.LanguageCode,
                    Label = t.Label
                })?.ToList() ?? new List<TranslationPermission>()
            }).ToList();
        }
    }
}