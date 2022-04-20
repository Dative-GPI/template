using System;

namespace XXXXX.Admin.Core
{
  public class RequestHeaders
  {
    public Guid ApplicationId { get; set; }
    public Guid OrganisationId { get; set; }
    public Guid ActorId { get; set; }
    public Guid RoleId { get; set; }
    public string LanguageCode { get; set; }
    public string Jwt { get; set; }
  }
}