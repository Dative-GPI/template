
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
    public class RouteRepository : IRouteRepository
    {
        private DbSet<RouteDTO> _dbSet;

        public RouteRepository(ApplicationContext context)
        {
            _dbSet = context.Routes;
        }

        public async Task<IEnumerable<RouteInfos>> GetMany(DrawerRoutesFilter filter)
        {
            var query = _dbSet
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.Search))
            {
                query = query.Where(route => route.Name.Contains(filter.Search));
            }

            IEnumerable<RouteDTO> dtos = await query.AsNoTracking().ToListAsync();

            return dtos.Select(routeDTO => new RouteInfos()
            {
                Id = routeDTO.Id,
                DrawerLabel = routeDTO.DrawerLabelDefault,
                Path = routeDTO.Path,
                Name = routeDTO.Name,
                DrawerIcon = routeDTO.DrawerIcon,
                DrawerCategory = routeDTO.DrawerCategory,
                Uri = routeDTO.Uri,
                Exact = routeDTO.Exact,
                ShowOnDrawer = routeDTO.ShowOnDrawer,
                Translations = routeDTO.Translations.Select(t => new TranslationRoute()
                {
                    LanguageCode = t.LanguageCode,
                    DrawerLabel = t.DrawerLabel
                }).ToList()
            });
        }
    }
}
