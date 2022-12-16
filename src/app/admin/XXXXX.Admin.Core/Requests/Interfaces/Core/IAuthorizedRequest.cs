using System.Collections.Generic;
using Bones.Flow;

namespace XXXXX.Admin.Core
{
    public interface IAuthorizedRequest : IRequest
    {
        IEnumerable<string> Authorizations { get; }
    }
}