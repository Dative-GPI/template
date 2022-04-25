using System;

namespace XXXXX.Domain.Models
{
    public class OrganisationTypePermission
    {
        public Guid Id { get; set; }
        public Guid PermissionId { get; set; }
        public string PermissionCode { get; set; }
    }
}