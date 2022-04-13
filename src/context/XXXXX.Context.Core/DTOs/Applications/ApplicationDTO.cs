using System;
using Bones.Repository.Interfaces;

namespace XXXXX.Context.Core.DTOs
{
    public class ApplicationDTO: IEntity<Guid>, IDTO
    {
        public Guid Id { get; set; }
        public string AdminHost { get; set; }
        public string ShellHost { get; set; }
        public bool Disabled { get; set; }
    }
}