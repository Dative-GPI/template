using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace XXXXX.Domain.Abstractions
{
    public interface IClaimsFactory
    {
        (Guid UserId, string RandomCookie, Guid ApplicationId, bool IsAdministrator) Get(ClaimsIdentity identity);
    }
}