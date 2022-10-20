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
    public class PermissionService : IPermissionService
    {
        private readonly IPermissionProvider _permissionProvider;
        private readonly IQueryHandler<PermissionCategoriesQuery, IEnumerable<PermissionCategory>> _categoriesQueryHandler;
        private readonly IMapper _mapper;

        public PermissionService(
            IPermissionProvider permissionProvider,
            IQueryHandler<PermissionCategoriesQuery, IEnumerable<PermissionCategory>> categoriesQueryHandler,
            IMapper mapper
        )
        {
            _permissionProvider = permissionProvider;
            _categoriesQueryHandler = categoriesQueryHandler;
            _mapper = mapper;
        }

        public async Task<IEnumerable<string>> GetCurrent(RequestHeaders headers, Guid organisationId)
        {
            return await _permissionProvider.GetPermissions(organisationId, headers.ActorId);
        }

        public async Task<IEnumerable<PermissionCategoryViewModel>> GetCategories(RequestHeaders headers, Guid organisationId)
        {
            var query = new PermissionCategoriesQuery() {
                ApplicationId = headers.ApplicationId,
                ActorId = headers.ActorId,
                OrganisationId = organisationId
            };

            var categories = await _categoriesQueryHandler.HandleAsync(query);

            return _mapper.Map<IEnumerable<PermissionCategory>, IEnumerable<PermissionCategoryViewModel>>(categories, opt => opt.Items.Add(LANGUAGE, headers.LanguageCode));
        }
    }
}