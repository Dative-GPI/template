using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using XXXXX.Context.Core.DTOs;

using XXXXX.Domain.Models;
using XXXXX.Domain.Repositories.Interfaces;

namespace XXXXX.Context.Core.Repositories
{
    public class PermissionCategoryRepository : IPermissionCategoryRepository
    {
        private DbSet<PermissionCategoryDTO> _categorySet;

        public PermissionCategoryRepository(ApplicationContext context)
        {
            _categorySet = context.PermissionCategories;
        }

        public async Task<IEnumerable<PermissionCategory>> GetMany()
        {
            var dtos = await _categorySet.AsNoTracking().ToListAsync();

            return dtos.Select(c => new PermissionCategory()
            {
                Label = c.LabelDefault,
                Prefix = c.Prefix,
                Translations = c.Translations?.Select(t => new TranslationPermissionCategory()
                {
                    Label = t.Label,
                    LanguageCode = t.LanguageCode
                }).ToList() ?? new List<TranslationPermissionCategory>()
            }).ToList();
        }
    }
}