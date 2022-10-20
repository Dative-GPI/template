using System.Collections.Generic;
using Bones.Flow;

namespace XXXXX.Domain
{
    public interface IAuthorizedRequest : IRequest
    {
        IEnumerable<string> Authorizations { get; }
    }
}