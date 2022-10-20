using System;

using Bones.Flow;

namespace XXXXX.Gateway.Core
{
    public class ThumbnailImageQuery : IRequest<byte[]>
    {        
        public Guid Id { get; set; }
    }
}