using System;
using System.Collections.Generic;
using Bones.Flow;

using XXXXX.Domain.Models;

namespace XXXXX.Gateway.Core {
    public class ApplicationTranslationsQuery : IRequest<IEnumerable<ApplicationTranslation>>
    {
        public Guid ApplicationId { get; set; }
        public Guid ActorId { get; set; }
        public string LanguageCode { get; set; }
        public Guid? OrganisationId { get; set; }
    }
}