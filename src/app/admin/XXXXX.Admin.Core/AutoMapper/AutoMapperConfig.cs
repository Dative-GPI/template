using System.Collections.Generic;

using AutoMapper;

namespace XXXXX.Admin.Core.AutoMapper
{
    public class AutoMapperConfig
    {
        public static List<Profile> Profiles = new List<Profile>()
        {
            new DomainToViewModelMappingProfile()
        };
    }
}