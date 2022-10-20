using System;
using System.Collections.Generic;

namespace XXXXX.Admin.Core.ViewModels
{
    public class UpdateApplicationTranslationViewModel
    {
        public string TranslationCode { get; set; }
        public Guid? OrganisationTypeId { get; set; }
        public string LanguageCode { get; set; }
        public string Value { get; set; }
    }
}