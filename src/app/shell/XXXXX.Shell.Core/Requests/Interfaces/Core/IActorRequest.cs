using System;
using Bones.Flow;

namespace XXXXX.Shell.Core
{
    public interface IActorRequest : IRequest
    {
        Guid ActorId { get; }
    }
}