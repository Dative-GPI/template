using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using Bones.Flow;
using Bones.Repository.Interfaces;

using XXXXX.Domain.Models;
using XXXXX.Domain.Repositories.Interfaces;
using XXXXX.admin.Core.Interfaces;
using XXXXX.Admin.Core.ViewModels;

namespace XXXXX.Admin.Core.Services
{
    public class RouteService : IRouteService
    {
        private IQueryHandler<RoutesQuery, IEnumerable<RouteInfos>> _extensionsQueryHandler;
        private IRouteRepository _extensionRepository;
        private IMapper _mapper;

        public RouteService(
            IQueryHandler<RoutesQuery, IEnumerable<RouteInfos>> extensionsQueryHandler,
            IRouteRepository extensionRepository,
            IMapper mapper
        ) {
            _extensionsQueryHandler = extensionsQueryHandler;
            _extensionRepository = extensionRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RouteInfosViewModel>> GetMany(Guid appId, Guid actorId, RoutesFilterViewModel filter)
        {
            var query = new RoutesQuery()
            {
                ApplicationId = appId,
                ActorId = actorId,
                Search = filter.Search
            };

            var result = await _extensionsQueryHandler.HandleAsync(query);

            return _mapper.Map<IEnumerable<RouteInfos>, IEnumerable<RouteInfosViewModel>>(result);
        }
    }
}
