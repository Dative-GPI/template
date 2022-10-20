using System;

namespace XXXXX.Shell.Core.Models
{
    public class RequestContext
    {
        public Guid ApplicationId { get; set; }
        public Guid ActorId { get; set; }

        public Guid? OrganisationId { get; set; }
        public string LanguageCode { get; set; }
        public string Jwt { get; set; }
    }
}