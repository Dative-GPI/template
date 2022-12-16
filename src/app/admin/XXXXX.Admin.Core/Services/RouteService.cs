using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using Bones.Flow;
using Bones.Repository.Interfaces;

using XXXXX.Domain.Models;
using XXXXX.Domain.Repositories.Interfaces;
using XXXXX.Admin.Core.Interfaces;
using XXXXX.Admin.Core.ViewModels;

namespace XXXXX.Admin.Core.Services
{
    public class RouteService : IRouteService
    {
        private IQueryHandler<RoutesQuery, IEnumerable<RouteInfos>> _routesQueryHandler;
        private IMapper _mapper;

        public RouteService(
            IQueryHandler<RoutesQuery, IEnumerable<RouteInfos>> routesQueryHandler,
            IMapper mapper
        ) {
            _routesQueryHandler = routesQueryHandler;
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

            var result = await _routesQueryHandler.HandleAsync(query);

            return _mapper.Map<IEnumerable<RouteInfos>, IEnumerable<RouteInfosViewModel>>(result);
        }
    }
}
