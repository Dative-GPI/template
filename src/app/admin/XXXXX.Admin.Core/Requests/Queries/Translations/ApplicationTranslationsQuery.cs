using System;
using System.Collections.Generic;

using Bones.Flow;
using Foundation.Clients;

using XXXXX.Domain.Models;

namespace XXXXX.Admin.Core.Requests
{
    public class ApplicationTranslationsQuery : ICoreRequest, IRequest<IEnumerable<ApplicationTranslation>>
    {
        public IEnumerable<string> Authorizations => new string[] { AdminAuthorizations.ADMIN_APPLICATIONTRANSLATION_INFOS };
        public Guid ApplicationId { get; set; }
        public Guid ActorId { get; set; }
    }
}