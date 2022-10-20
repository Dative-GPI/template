using System;
using System.Collections.Generic;

namespace XXXXX.Domain.Repositories.Filters
{
    public class ApplicationTranslationFilter
    {
        public Guid ApplicationId { get; set; }
        public string Prefix { get; set; }
        public string LanguageCode { get; set; }
        public IEnumerable<Guid?> OrganisationTypeIds { get; set; }
        public IEnumerable<string> Codes { get; set; }
    }
}