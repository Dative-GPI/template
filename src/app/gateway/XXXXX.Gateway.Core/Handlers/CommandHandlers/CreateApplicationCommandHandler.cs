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
            IEntity<Guid> result;

            var app = await _applicationRepository.Get(request.ApplicationId);

            if (app != null)
            {
                result = await _applicationRepository.Update(new UpdateApplication()
                {
                    AdminHost = request.AdminHost,
                    AdminJWT = request.AdminJWT,
                    ApplicationId = app.Id,
                    ShellHost = request.ShellHost
                });
            }
            else
            {
                result = await _applicationRepository.Create(new CreateApplication()
                {
                    ApplicationId = request.ApplicationId,
                    AdminHost = request.AdminHost,
                    ShellHost = request.ShellHost,
                    AdminJWT = request.AdminJWT
                });
            }

            return result;
        }
    }
}