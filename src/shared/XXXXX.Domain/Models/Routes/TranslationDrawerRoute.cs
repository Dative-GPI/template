using System;

namespace XXXXX.Domain.Models
{
    public class TranslationDrawerRoute : ITranslation
    {
        public Guid LanguageId { get; set; }
        public string Label { get; set; }
    }
}