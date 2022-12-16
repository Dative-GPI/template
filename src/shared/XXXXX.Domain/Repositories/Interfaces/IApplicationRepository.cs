using System;
using System.Threading.Tasks;
using Bones.Repository.Interfaces;

using XXXXX.Domain.Models;
using XXXXX.Domain.Repositories.Commands;

namespace XXXXX.Domain.Repositories.Interfaces 
{
    public interface IApplicationRepository 
    {
        Task<ApplicationDetails> Get(Guid applicationId);
        Task<IEntity<Guid>> Create(CreateApplication payload);
        Task<IEntity<Guid>> Update(UpdateApplication payload);
        Task Remove(Guid id);
    }
}