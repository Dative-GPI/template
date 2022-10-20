using System;
using Bones.Flow;

namespace XXXXX.Shell.Core
{
    public interface IApplicationRequest : IRequest
    {
        Guid ApplicationId { get; }
    }
}