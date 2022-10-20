using System;
using System.Collections.Generic;

namespace Foundation.Clients.ViewModels.Shell
{
    public class UserOrganisationDetailsViewModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        // public UserValidityState Validity { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public List<string> Tags { get; set; }
        public Guid? ImageId { get; set; }
        public string ImageBlurHash { get; set; }
        public int? ImageHeight { get; set; }
        public int? ImageWidth { get; set; }
        public Guid? RoleId { get; set; }
        public Guid OrganisationId { get; set; }
        public bool AllLocations { get; set; }
        // public List<UserOrganisationLocationViewModel> Locations { get; set; }
        public string LanguageCode { get; set; }
        public string TimeZoneId { get; set; }

        public List<string> Permissions { get; set; }


        #region Translated properties
        public string RoleLabel { get; set; }
        #endregion
    }
}