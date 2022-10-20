using System;
using Bones.Flow;

namespace XXXXX.Shell.Core
{
    public interface IOrganisationRequest : IRequest
    {
        Guid OrganisationId { get; }
    }
}