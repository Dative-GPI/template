using System;

namespace XXXXX.Domain.Models
{
  public class Headers
    {
        public Guid ApplicationId { get; set; }
        public Guid OrganisationId { get; set; }
        public Guid ActorId { get; set; }
        public Guid LanguageId { get; set; }
        public Guid? ExtensionId { get; set; }
    }
}