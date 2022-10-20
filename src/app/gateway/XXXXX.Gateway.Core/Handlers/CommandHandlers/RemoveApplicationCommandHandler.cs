using System;
using System.Threading;
using System.Threading.Tasks;

using Bones.Flow;

using XXXXX.Domain.Repositories.Interfaces;
using XXXXX.Gateway.Core.Requests.Commands;

namespace XXXXX.Gateway.Core.Handlers
{
    public class RemoveApplicationCommandHandler : IMiddleware<RemoveApplicationCommand>
    {
        private IApplicationRepository _applicationRepository;

        public RemoveApplicationCommandHandler(IApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }

        public async Task HandleAsync(RemoveApplicationCommand request, Func<Task> next, CancellationToken cancellationToken)
        {
            await _applicationRepository.Remove(request.ApplicationId);
        }
    }
}