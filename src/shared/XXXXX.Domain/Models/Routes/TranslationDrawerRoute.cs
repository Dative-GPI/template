using System;

namespace XXXXX.Domain.Models
{
    public class TranslationRoute : ITranslation
    {
        public string LanguageCode { get; set; }
        public string DrawerLabel { get; set; }
    }
}