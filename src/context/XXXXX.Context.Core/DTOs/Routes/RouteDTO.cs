using System;
using System.Collections.Generic;

using Bones.Repository.Interfaces;

namespace XXXXX.Context.Core.DTOs
{
    public class RouteDTO : IEntity<Guid>, IDTO
    {
        public Guid Id { get; set; }

        public bool ShowOnDrawer { get; set; }
        public string DrawerIcon { get; set; }
        public string DrawerCategory { get; set; }
        public string DrawerLabelDefault { get; set; }

        public string Path { get; set; }
        public string Uri { get; set; }
        public string Name { get; set; }

        public bool Exact { get; set; }
        public List<TranslationRouteDTO> Translations { get; set; }
        public bool Disabled { get; set; }
    }

    public class TranslationRouteDTO
    {
        public string LanguageCode { get; set; }
        public string DrawerLabel { get; set; }
    }
}