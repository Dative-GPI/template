using System;
using System.Collections.Generic;

namespace XXXXX.Domain.Repositories.Filters
{
    public class PermissionAdminFilter
    {
        public Guid? RoleAdminId { get; set; }
        public string Search { get; set; }
        public IEnumerable<Guid> PermissionAdminIds { get; set; }
    }
}