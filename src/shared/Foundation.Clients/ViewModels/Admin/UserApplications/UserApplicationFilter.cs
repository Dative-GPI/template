using System;
using System.Collections.Generic;

namespace Foundation.Clients.ViewModels.Admin
{
    public class UserApplicationFilter
    {
        public Guid? UserId { get; set; }
        public string Search { get; set; }
    }
}