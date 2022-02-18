using System;
using System.Security.Claims;
using System.Threading.Tasks;

using static XXXXX.Domain.ClaimsKeys;
using XXXXX.Domain.Repositories.Interfaces;

using System.Linq;
using XXXXX.Domain.Abstractions;

namespace XXXXX.CrossCutting.Services
{
    public class ClaimsFactory : IClaimsFactory
    {

        public ClaimsFactory()
        {
        }

        public (Guid UserId, string RandomCookie, Guid ApplicationId, bool IsAdministrator) Get(ClaimsIdentity identity)
        {
            var userIdClaim = identity.Claims.SingleOrDefault(c => c.Type == USER_ID);
            Guid.TryParse(userIdClaim?.Value, out var userId);

            var randomCookieClaim = identity.Claims.SingleOrDefault(c => c.Type == RANDOM_COOKIE);
            string randomCookie = randomCookieClaim?.Value;

            var applicationIdClaim = identity.Claims.SingleOrDefault(c => c.Type == APPLICATION_ID);
            Guid.TryParse(applicationIdClaim?.Value, out var applicationId);

            var isAdministratorClaim = identity.Claims.SingleOrDefault(c => c.Type == ADMINISTRATOR);
            Boolean.TryParse(isAdministratorClaim?.Value, out var isAdministrator);

            return (
                userId,
                randomCookie,
                applicationId,
                isAdministrator
            );
        }

    }
}