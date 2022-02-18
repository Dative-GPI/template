using System;

namespace XXXXX.Domain.Models
{
    public class Translation : ITranslation
    {
        public Guid LanguageId { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
    }
}