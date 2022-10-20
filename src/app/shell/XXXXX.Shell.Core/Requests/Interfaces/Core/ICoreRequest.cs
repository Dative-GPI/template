using Bones.Flow;
using XXXXX.Domain;

namespace XXXXX.Shell.Core
{
    public interface ICoreRequest : IApplicationRequest, IActorRequest,
        IAuthorizedRequest, IOrganisationRequest, IRequest
    {
    }
}