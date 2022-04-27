using AutoMapper;
using XXXXX.Domain.Models;
using XXXXX.Shell.Core.ViewModels;

namespace XXXXX.Shell.Core.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<RouteInfos, RouteInfosViewModel>();
        }
    }
}