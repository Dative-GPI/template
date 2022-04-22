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
        private DbSet<PermissionCategoryDTO> _categorySet;

        public PermissionRepository(ApplicationContext context)
        {
            _dbSet = context.Permissions;
            _categorySet = context.PermissionCategories;
        }

        public async Task<IEnumerable<PermissionCategory>> GetCategories()
        {
            var set = await _categorySet.ToListAsync();
            return set.Select(c => new PermissionCategory()
            {
                Label = c.LabelDefault,
                Prefix = c.Prefix,
                Translations = c.Translations?.Select(t => new TranslationPermissionCategory()
                {
                    Label = t.Label,
                    LanguageId = t.LanguageId
                })?.ToList() ?? new List<TranslationPermissionCategory>()
            }).ToList();
        }

        public async Task<IEnumerable<PermissionInfos>> GetMany(PermissionsFilter filter)
        {
            var set = _dbSet
                .Include(p => p.PermissionOrganisationTypes)
                .AsQueryable();

            if (filter.Ids != null)
            {
                set = set.Where(p => filter.Ids.Contains(p.Id));
            }

            if (!String.IsNullOrWhiteSpace(filter.Search))
            {

            }

            if (filter.OrganisationTypeId.HasValue)
            {
                set = set.Where(p => p.PermissionOrganisationTypes.Any(pr => pr.OrganisationTypeId == filter.OrganisationTypeId.Value));
            }

            IEnumerable<PermissionDTO> dtos = await set.AsNoTracking().ToListAsync();

            return dtos.Select(permissionDTO => new PermissionInfos()
            {
                Id = permissionDTO.Id,
                Code = permissionDTO.Code,
                Label = permissionDTO.LabelDefault,
                Translations = permissionDTO.Translations?.Select(t => new TranslationPermission()
                {
                    LanguageId = t.LanguageId,
                    Label = t.Label
                })?.ToList() ?? new List<TranslationPermission>()
            }).ToList();
        }
    }
}