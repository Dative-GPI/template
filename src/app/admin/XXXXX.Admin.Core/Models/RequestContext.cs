using System;

namespace XXXXX.Admin.Core.Models
{
    public class RequestContext
    {
        public Guid ApplicationId { get; set; }
        public Guid ActorId { get; set; }

        public string LanguageCode { get; set; }
        public string Jwt { get; set; }
    }
}