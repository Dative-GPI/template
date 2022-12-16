using System;
using Bones.Flow;

namespace XXXXX.Admin.Core
{
    public interface IApplicationRequest : IRequest
    {
        Guid ApplicationId { get; }
    }
}