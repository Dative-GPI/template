using System;

namespace XXXXX.Domain.Models
{
    public class TranslationRoute : ITranslation
    {
        public Guid LanguageId { get; set; }
        public string DrawerLabel { get; set; }
    }
}