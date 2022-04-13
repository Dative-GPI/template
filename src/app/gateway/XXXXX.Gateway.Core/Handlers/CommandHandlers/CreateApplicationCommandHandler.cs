using System;
using System.Threading;
using System.Threading.Tasks;
using Bones.Flow;
using Bones.Repository.Interfaces;
using XXXXX.Domain.Repositories.Commands;
using XXXXX.Domain.Repositories.Interfaces;
using XXXXX.Gateway.Core.Requests.Commands;

namespace XXXXX.Gateway.Core.Handlers
{
    public class CreateApplicationCommandHandler : IMiddleware<CreateApplicationCommand, IEntity<Guid>>
    {
        private IApplicationRepository _applicationRepository;

        public CreateApplicationCommandHandler(IApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }

        public async Task<IEntity<Guid>> HandleAsync(CreateApplicationCommand request, Func<Task<IEntity<Guid>>> next, CancellationToken cancellationToken)
        {

            var createApplication = new CreateApplication()
            {
                ApplicationId = request.ApplicationId,
                AdminHost = request.AdminHost,
                ShellHost = request.ShellHost,
            };

            return await _applicationRepository.Create(createApplication);
        }
    }
}