using AutoMapper;
using XXXXX.Admin.Core.ViewModels;
using XXXXX.Domain.Models;

namespace XXXXX.Admin.Core.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<RouteInfos, RouteInfosViewModel>()
                .ForMember(r => r.DrawerLabel, opt => opt.MapFromTranslation(e => e.Translations, t => t.DrawerLabel));
        }
    }
}