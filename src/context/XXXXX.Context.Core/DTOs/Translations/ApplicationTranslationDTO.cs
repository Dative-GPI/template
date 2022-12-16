using System;
using System.Collections.Generic;
using Bones.Repository.Interfaces;

namespace XXXXX.Context.Core.DTOs
{
    public class ApplicationTranslationDTO : IEntity<Guid>, IDTO
    {
        public Guid Id { get; set; }

        public Guid ApplicationId { get; set; }
        public ApplicationDTO Application { get; set; }

        public Guid? OrganisationTypeId { get; set; }

        public Guid TranslationId { get; set; }
        public TranslationDTO Translation { get; set; }

        public string LanguageCode { get; set; }
        public string Value { get; set; }
        public bool Disabled { get; set; }
    }
}