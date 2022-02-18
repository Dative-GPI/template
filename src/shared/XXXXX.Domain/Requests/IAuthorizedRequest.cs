using System.Collections.Generic;

namespace XXXXX.Domain
{
    public interface IAuthorizedRequest
    {
        IEnumerable<string> Authorizations { get; }
    }
}