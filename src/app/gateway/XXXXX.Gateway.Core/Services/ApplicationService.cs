using System;
using System.Threading.Tasks;
using AutoMapper;
using Bones.Flow;
using Bones.Repository.Interfaces;
using Microsoft.Extensions.Logging;

using XXXXX.Domain.Models;
using XXXXX.Domain.Repositories.Interfaces;
using XXXXX.Gateway.Core.Interfaces;
using XXXXX.Gateway.Core.Requests.Commands;
using XXXXX.Gateway.Core.ViewModels;

namespace XXXXX.Gateway.Core.Services
{
    public class ApplicationService : IApplicationService
    {
        private ILogger<ApplicationService> _logger;
        private IMapper _mapper;
        private IApplicationRepository _applicationRepository;
        private ICommandHandler<CreateApplicationCommand, IEntity<Guid>> _createApplicationCommandHandler;
        private ICommandHandler<RemoveApplicationCommand> _removeApplicationCommandHandler;

        public ApplicationService(
            ILogger<ApplicationService> logger,
            IMapper mapper,
            IApplicationRepository applicationRepository,
            ICommandHandler<CreateApplicationCommand, IEntity<Guid>> createApplicationCommandHandler,
            ICommandHandler<RemoveApplicationCommand> removeApplicationCommandHandler
        )
        {
            _logger = logger;
            _mapper = mapper;
            _applicationRepository = applicationRepository;
            _createApplicationCommandHandler = createApplicationCommandHandler;
            _removeApplicationCommandHandler = removeApplicationCommandHandler;            
        }

        public async Task<ApplicationDetailsViewModel> Create(CreateApplicationViewModel payload)
        {
            var command = new CreateApplicationCommand()
            {
                ApplicationId = payload.ApplicationId,
                AdminHost = payload.AdminHost,
                ShellHost = payload.ShellHost,
                AdminJWT = payload.AdminJWT
            };

            var result = await _createApplicationCommandHandler.HandleAsync(command);
            var application = await _applicationRepository.Get(result.Id);

            return _mapper.Map<ApplicationDetails, ApplicationDetailsViewModel>(application);
        }

        public async Task Remove(Guid actorId, Guid applicationId)
        {
            var command = new RemoveApplicationCommand()
            {
                ApplicationId = applicationId
            };
            
            await _removeApplicationCommandHandler.HandleAsync(command);
        }
    }
}