using System;
using System.Collections.Generic;

using Bones.Repository.Interfaces;

namespace XXXXX.Context.Core.DTOs
{
    public class PermissionDTO : IEntity<Guid>, IDTO
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string LabelDefault { get; set; }
        public List<OrganisationTypePermissionDTO> OrganisationTypePermissions { get; set; }
        public List<TranslationPermissionDTO> Translations { get; set; }
        public bool Disabled { get; set; }
    }

    public class TranslationPermissionDTO
    {
        public Guid LanguageId { get; set; }
        public string Label { get; set; }
    }
}
