using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;
using Bones.Flow;

using XXXXX.Domain.Models;
using XXXXX.Shell.Core.Abstractions;
using XXXXX.Shell.Core.Interfaces;
using XXXXX.Shell.Core.ViewModels;

using static XXXXX.Shell.Core.AutoMapper.Consts;

namespace XXXXX.Shell.Core.Services
{
    public class OrganisationPermissionService : IOrganisationPermissionService
    {
        private readonly IQueryHandler<OrganisationPermissionsQuery, IEnumerable<PermissionInfos>> _organisationPermissionsQueryHandler;
        private readonly IMapper _mapper;

        public OrganisationPermissionService(
            IQueryHandler<OrganisationPermissionsQuery, IEnumerable<PermissionInfos>> organisationPermissionsQueryHandler,
            IMapper mapper
        )
        {
            _organisationPermissionsQueryHandler = organisationPermissionsQueryHandler;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PermissionInfosViewModel>> GetMany(RequestHeaders headers, Guid organisationId)
        {
            var query = new OrganisationPermissionsQuery() {
                ApplicationId = headers.ApplicationId,
                ActorId = headers.ActorId,
                OrganisationId = organisationId
            };

            var permissions = await _organisationPermissionsQueryHandler.HandleAsync(query);

            return _mapper.Map<IEnumerable<PermissionInfos>, IEnumerable<PermissionInfosViewModel>>(permissions, opt => opt.Items.Add(LANGUAGE, headers.LanguageCode));
        }
    }
}