using System;
using System.Collections.Generic;

namespace Foundation.Clients.ViewModels.Admin
{
    public class UserApplicationDetailsViewModel
    {
        public Guid Id { get; set; }
        public bool Verified { get; set; }
        // public UserValidityState Validity { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name => $"{FirstName} {LastName}";
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Guid? RoleAdminId { get; set; }
        public string RoleAdminLabel { get; set; }
        public string LanguageCode { get; set; }
        public string TimeZoneId { get; set; }
        public Guid ImageId { get; set; }
        public int ImageWidth { get; set; }
        public int ImageHeight { get; set; }
        public string ImageBlurHash { get; set; }
        // public List<PermissionInfosViewModel> Permissions { get; set; }
    }
}