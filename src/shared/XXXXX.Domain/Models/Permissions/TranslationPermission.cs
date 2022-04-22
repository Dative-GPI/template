using System;

namespace XXXXX.Domain.Models
{
    public class TranslationPermission : ITranslation
    {
        public Guid LanguageId { get; set; }
        public string Label { get; set; }
    }
}