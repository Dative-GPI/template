using AutoMapper;

using XXXXX.Domain.Models;
using XXXXX.Shell.Core.ViewModels;

namespace XXXXX.Shell.Core.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            ForAllMaps(TranslationMapper.Map);

            CreateMap<ImageInfos, ImageViewModel>();
            CreateMap<RouteInfos, RouteInfosViewModel>();

            CreateMap<PermissionInfos, PermissionInfosViewModel>();
            CreateMap<PermissionCategory, PermissionCategoryViewModel>();
        }
    }
}