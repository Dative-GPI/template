using AutoMapper;
using XXXXX.Domain.Models;
using XXXXX.Gateway.Core.ViewModels;

namespace XXXXX.Gateway.Core.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<ApplicationDetails, ApplicationDetailsViewModel>();
            CreateMap<ApplicationTranslation, ApplicationTranslationViewModel>();
        }
    }
}