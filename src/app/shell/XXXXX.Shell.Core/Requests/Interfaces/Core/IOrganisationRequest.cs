using System;
using Bones.Flow;

namespace XXXXX.Domain
{
    public interface IOrganisationRequest : IRequest
    {
        Guid OrganisationId { get; }
    }
}