using System;
using Bones.Flow;

namespace XXXXX.Gateway.Core
{
    public class RawImageQuery : IRequest<byte[]>
    {        
        public Guid Id { get; set; }
    }
}