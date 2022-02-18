using System;
using System.Collections.Generic;

using Bones.Repository.Interfaces;

namespace XXXXX.Context.Core.DTOs
{
    public class DrawerRouteDTO : IEntity<Guid>, IDTO
    {
        public Guid Id { get; set; }
        public string Path { get; set; }
        public string Uri { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Code { get; set; }
        public string LabelDefault { get; set; }
        public List<TranslationDrawerRouteDTO> Translations { get; set; }
        public bool Disabled { get; set; }
    }

    public class TranslationDrawerRouteDTO
    {
        public Guid LanguageId { get; set; }
        public string Label { get; set; }
    }
}