using System;
using Bones.Flow;

namespace XXXXX.Domain
{
    public interface IApplicationRequest : IRequest
    {
        Guid ApplicationId { get; }
    }
}