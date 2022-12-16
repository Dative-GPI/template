using System;
using System.Collections.Generic;

namespace XXXXX.Admin.Core.ViewModels
{
    public class PermissionAdminFilterViewModel
    {
        public string Search { get; set; }
        public Guid? RoleAdminId { get; set; }
        public IEnumerable<Guid> PermissionAdminIds { get; set; }
    }
}