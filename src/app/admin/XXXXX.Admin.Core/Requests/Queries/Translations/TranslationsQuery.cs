using System;
using System.Collections.Generic;

using Bones.Flow;
using Foundation.Clients;

using XXXXX.Domain.Models;

namespace XXXXX.Admin.Core.Requests
{
    public class TranslationsQuery : ICoreRequest, IRequest<IEnumerable<Translation>>
    {
        public IEnumerable<string> Authorizations => new string[] { AdminAuthorizations.ADMIN_TRANSLATION_INFOS };
        public Guid ApplicationId { get; set; }
        public Guid ActorId { get; set; }
    }
}