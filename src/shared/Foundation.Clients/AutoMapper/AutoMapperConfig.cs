using System.Collections.Generic;

using AutoMapper;

namespace Foundation.Clients.AutoMapper
{
    public class AutoMapperConfig
    {
        public static List<Profile> Profiles = new List<Profile>()
        {
            new ViewModelToDomainMappingProfile()
        };
    }
}