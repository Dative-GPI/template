using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using Bones.Flow;
using Bones.Repository.Interfaces;

using XXXXX.Domain.Models;
using XXXXX.Domain.Repositories.Interfaces;
using XXXXX.Shell.Core.Interfaces;
using XXXXX.Shell.Core.ViewModels;

namespace XXXXX.Shell.Core.Services
{
    public class RouteService : IRouteService
    {
        private IQueryHandler<RoutesQuery, IEnumerable<RouteInfos>> _routesQueryHandler;
        private IRouteRepository _routeRepository;
        private IMapper _mapper;

        public RouteService(
            IQueryHandler<RoutesQuery, IEnumerable<RouteInfos>> routesQueryHandler,
            IRouteRepository routeRepository,
            IMapper mapper
        ) {
            _routesQueryHandler = routesQueryHandler;
            _routeRepository = routeRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RouteInfosViewModel>> GetMany(RequestHeaders headers, Guid organisationId, RoutesFilterViewModel filter)
        {
            var query = new RoutesQuery()
            {
                ApplicationId = headers.ApplicationId,
                ActorId = headers.ActorId,
                OrganisationId = organisationId,
                Search = filter.Search
            };

            var result = await _routesQueryHandler.HandleAsync(query);

            return _mapper.Map<IEnumerable<RouteInfos>, IEnumerable<RouteInfosViewModel>>(result);
        }
    }
}
