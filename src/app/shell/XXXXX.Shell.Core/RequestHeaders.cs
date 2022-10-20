using System;

namespace XXXXX.Shell.Core
{
    public class RequestHeaders
    {
        public Guid ApplicationId { get; set; }
        public Guid ActorId { get; set; }
        
        public string LanguageCode { get; set; }
        public string Jwt { get; set; }
    }
}