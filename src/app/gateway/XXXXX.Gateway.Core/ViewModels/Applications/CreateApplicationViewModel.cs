using System;

namespace XXXXX.Gateway.Core.ViewModels
{
    public class CreateApplicationViewModel
    {
        public Guid ApplicationId { get; set; }
        public string AdminHost { get; set; }
        public string ShellHost { get; set; }
    }
}