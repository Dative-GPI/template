
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using XXXXX.Domain.Models;
using XXXXX.Domain.Repositories.Filters;
using XXXXX.Domain.Repositories.Interfaces;
using XXXXX.Context.Core.DTOs;

namespace XXXXX.Context.Core.Repositories
{
    public class DrawerRouteRepository : IDrawerRouteRepository
    {
        private DbSet<DrawerRouteDTO> _dbSet;

        public DrawerRouteRepository(ApplicationContext context)
        {
            _dbSet = context.Routes;
        }

        public async Task<IEnumerable<DrawerRouteInfos>> GetMany(DrawerRoutesFilter filter)
        {
            var query = _dbSet
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.Search))
            {
                query = query.Where(route => route.Name.Contains(filter.Search));
            }

            IEnumerable<DrawerRouteDTO> dtos = await query.AsNoTracking().ToListAsync();

            return dtos.Select(routeDTO => new DrawerRouteInfos()
            {
                Id = routeDTO.Id,
                Label = routeDTO.LabelDefault,
                Path = routeDTO.Path,
                Name = routeDTO.Name,
                Icon = routeDTO.Icon,
                Code = routeDTO.Code,
                Uri = routeDTO.Uri,
                Translations = routeDTO.Translations.Select(t => new TranslationDrawerRoute()
                {
                    LanguageId = t.LanguageId,
                    Label = t.Label
                }).ToList()
            });


        }
    }
}
