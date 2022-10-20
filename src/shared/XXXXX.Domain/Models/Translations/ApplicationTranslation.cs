using System;

namespace XXXXX.Domain.Models
{
    public class ApplicationTranslation
    {
        public Guid Id { get; set; }
        public string LanguageCode { get; set; }
        public Guid? OrganisationTypeId { get; set; }
        public string TranslationCode { get; set; }
        public string Value { get; set; }
    }
}