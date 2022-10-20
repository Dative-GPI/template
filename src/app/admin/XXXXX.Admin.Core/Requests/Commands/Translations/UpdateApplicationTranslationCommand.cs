using System;
using System.Collections.Generic;

using Bones.Flow;
using Foundation.Clients;

using static XXXXX.Admin.Core.Authorizations;

namespace XXXXX.Admin.Core.Requests
{
    public class UpdateApplicationTranslationCommand : ICoreRequest, IRequest
    {
        public IEnumerable<string> Authorizations => new[] { AdminAuthorizations.ADMIN_APPLICATIONTRANSLATION_UPDATE };
        public Guid ApplicationId { get; set; }
        public Guid ActorId { get; set; }

        public List<UpdateApplicationTranslation> ApplicationTranslations { get; set; }
    }

    public class UpdateApplicationTranslation
    {
        public string LanguageCode { get; set; }
        public Guid? OrganisationTypeId { get; set; }
        public string Value { get; set; }
        public string TranslationCode { get; set; }
    }
}