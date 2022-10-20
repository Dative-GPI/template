using System;

namespace XXXXX.Admin.Core.ViewModels
{
    public class ApplicationTranslationViewModel
    {
        public Guid Id { get; set; }
        public string Code => TranslationCode;
        public string TranslationCode { get; set; }
        public string LanguageCode { get; set; }
        public Guid? OrganisationTypeId { get; set; }
        public string Value { get; set; }
    }
}