

using System;
using Bones.Flow;
using Bones.Repository.Interfaces;

namespace XXXXX.Gateway.Core.Requests.Commands
{
    public class CreateApplicationCommand : IRequest<IEntity<Guid>>
    {
        public Guid ApplicationId { get; set; }
        public string AdminHost { get; set; }
        public string ShellHost { get; set; }
        public string AdminJWT { get; set; }
    }
}