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
    public class TranslationRepository : ITranslationRepository
    {
        private ApplicationContext _context;
        private DbSet<TranslationDTO> _dbSet;

        public TranslationRepository(ApplicationContext context)
        {
            _context = context;
            _dbSet = context.Translations;
        }

        public async Task<IEnumerable<Translation>> GetMany()
        {
            var result = await _dbSet.ToListAsync();
            return result.Select(r => new Translation()
            {
                Id = r.Id,
                Code = r.Code,
                Value = r.ValueDefault
            });
        }
    }
}