using System;
using Bones.Flow;

namespace XXXXX.Admin.Core
{
    public interface IActorRequest : IRequest
    {
        Guid ActorId { get; }
    }
}