

using System;
using Bones.Flow;

namespace XXXXX.Gateway.Core.Requests.Commands
{
    public class RemoveApplicationCommand : IRequest
    {
        public Guid ApplicationId { get; set; }
    }
}