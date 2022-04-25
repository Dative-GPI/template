using System;

namespace XXXXX.Domain.Repositories.Commands
{
    public class UpdateOrganisationTypePermissions
    {
        public Guid OrganisationTypeId { get; set; }
        public Guid PermissionsId { get; set; }
    }
}