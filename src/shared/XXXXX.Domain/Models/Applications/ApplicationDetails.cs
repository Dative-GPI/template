using System;

namespace XXXXX.Domain.Models
{
    public class ApplicationDetails
    {
        public Guid Id { get; set; }
        public string ShellHost { get; set; }
        public string AdminHost { get; set; }
        public string AdminJWT { get; set; }
        public bool Disabled { get; set; }
    }
}