using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace XXXXX.Domain.Abstractions
{
    public interface IClaimsFactory
    {
        (Guid? UserId, Guid? SourceId, string RandomCookie, Guid ApplicationId, bool IsAdministrator, string LanguageCode) Get(IEnumerable<Claim> identity);
    }
}