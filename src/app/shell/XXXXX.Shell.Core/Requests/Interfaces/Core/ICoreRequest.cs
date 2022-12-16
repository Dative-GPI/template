using Bones.Flow;

namespace XXXXX.Shell.Core
{
    public interface ICoreRequest : IApplicationRequest, IActorRequest,
        IAuthorizedRequest, IOrganisationRequest, IRequest
    {
    }
}