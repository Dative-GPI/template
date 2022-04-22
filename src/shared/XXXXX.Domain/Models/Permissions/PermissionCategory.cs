using System;
using System.Collections.Generic;

namespace XXXXX.Domain.Models
{
    public class PermissionCategory: ITranslatable<TranslationPermissionCategory>
    {
        public string Label { get; set; }
        public string Prefix { get; set; }
        public List<TranslationPermissionCategory> Translations { get; set; }
    }

    public class TranslationPermissionCategory: ITranslation
    {
        public Guid LanguageId { get; set; }
        public string Label { get; set; }
    }
}