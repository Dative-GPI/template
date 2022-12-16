using Bones.Flow;

namespace XXXXX.Admin.Core
{
    public interface ICoreRequest :  IApplicationRequest, IActorRequest,
        IAuthorizedRequest, IRequest
    {
    }
}