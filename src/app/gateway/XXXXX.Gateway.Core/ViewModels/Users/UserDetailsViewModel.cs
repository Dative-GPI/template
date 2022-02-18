using System;
using System.Collections.Generic;

namespace XXXXX.Gateway.Core.ViewModels
{
  public class UserDetailsViewModel
  {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Guid RoleId { get; set; }
        public Guid OrganisationId { get; set; }
        public Guid LanguageId { get; set; }
        public List<string> Tags { get; set; }
        public string RoleLabel { get; set; }
  }
}