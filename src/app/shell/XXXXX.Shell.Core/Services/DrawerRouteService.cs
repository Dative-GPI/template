using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using Bones.Flow;
using Bones.Repository.Interfaces;

using XXXXX.Domain.Models;
using XXXXX.Domain.Repositories.Interfaces;
using XXXXX.shell.Core.Interfaces;
using XXXXX.Shell.Core.ViewModels;

namespace XXXXX.Shell.Core.Services
{
    public class DrawerRouteService : IDrawerRouteService
    {
        private IQueryHandler<DrawerRoutesQuery, IEnumerable<DrawerRouteInfos>> _extensionsQueryHandler;
        private IDrawerRouteRepository _extensionRepository;
        private IMapper _mapper;

        public DrawerRouteService(
            IQueryHandler<DrawerRoutesQuery, IEnumerable<DrawerRouteInfos>> extensionsQueryHandler,
            IDrawerRouteRepository extensionRepository,
            IMapper mapper
        ) {
            _extensionsQueryHandler = extensionsQueryHandler;
            _extensionRepository = extensionRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<DrawerRouteInfosViewModel>> GetMany(Guid appId, Guid actorId, DrawerRoutesFilterViewModel filter)
        {
            var query = new DrawerRoutesQuery()
            {
                ApplicationId = appId,
                ActorId = actorId,
                Search = filter.Search
            };

            var result = await _extensionsQueryHandler.HandleAsync(query);

            return _mapper.Map<IEnumerable<DrawerRouteInfos>, IEnumerable<DrawerRouteInfosViewModel>>(result);
        }
    }
}
