using AutoMapper;

using XXXXX.Admin.Core.ViewModels;
using XXXXX.Domain.Models;

namespace XXXXX.Admin.Core.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<PermissionCategory, PermissionCategoryViewModel>()
                .ForMember(p => p.Label, opt => opt.MapFromTranslation(e => e.Translations, t => t.Label));
            CreateMap<PermissionDetails, PermissionDetailsViewModel>()
                .ForMember(p => p.Label, opt => opt.MapFromTranslation(e => e.Translations, t => t.Label));
            CreateMap<PermissionInfos, PermissionInfosViewModel>()
                .ForMember(p => p.Label, opt => opt.MapFromTranslation(e => e.Translations, t => t.Label));

            CreateMap<PermissionAdminCategory, PermissionAdminCategoryViewModel>()
                .ForMember(p => p.Label, opt => opt.MapFromTranslation(e => e.Translations, t => t.Label));
            CreateMap<PermissionAdminDetails, PermissionAdminDetailsViewModel>()
                .ForMember(p => p.Label, opt => opt.MapFromTranslation(e => e.Translations, t => t.Label));
            CreateMap<PermissionAdminInfos, PermissionAdminInfosViewModel>()
                .ForMember(p => p.Label, opt => opt.MapFromTranslation(e => e.Translations, t => t.Label));

            CreateMap<RouteInfos, RouteInfosViewModel>();

            CreateMap<Translation, TranslationViewModel>();
            CreateMap<ApplicationTranslation, ApplicationTranslationViewModel>();
        }
    }
}