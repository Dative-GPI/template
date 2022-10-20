using System.Collections.Generic;
using Bones.Flow;

namespace XXXXX.Shell.Core
{
    public interface IAuthorizedRequest : IRequest
    {
        IEnumerable<string> Authorizations { get; }
    }
}