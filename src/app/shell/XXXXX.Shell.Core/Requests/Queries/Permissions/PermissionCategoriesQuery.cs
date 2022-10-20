using System;
using System.Collections.Generic;

using Bones.Flow;

using Foundation.Clients;
using XXXXX.Domain.Models;

namespace XXXXX.Shell.Core
{
    public class PermissionCategoriesQuery : ICoreRequest, IRequest<IEnumerable<PermissionCategory>>
    {
        public IEnumerable<string> Authorizations => new string[] {};
        public Guid ApplicationId { get; set; }
        public Guid ActorId { get; set; }
        public Guid OrganisationId { get; set; }
    }
}