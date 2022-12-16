using System;

namespace XXXXX.Domain.Repositories.Commands
{
    public class CreateApplication
    {
        public Guid ApplicationId { get; set; }   
        public string ShellHost { get; set; }
        public string AdminHost { get; set; }
        public string AdminJWT { get; set; }
    }
}