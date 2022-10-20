using System;
using Bones.Flow;

namespace XXXXX.Domain
{
    public interface IActorRequest : IRequest
    {
        Guid ActorId { get; }
    }
}