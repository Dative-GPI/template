using System;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;

using Foundation.Clients.Abstractions;

using XXXXX.Domain.Repositories.Interfaces;

using XXXXX.Shell.Core.Abstractions;
using XXXXX.Shell.Core.Models;

namespace XXXXX.Shell.Core.Tools
{
    public class FoundationClientFactory : IFoundationClientFactory
    {
        private IServiceProvider _sp;
        private IApplicationRepository _applicationRepository;
        private RequestContext _context;

        public FoundationClientFactory(
            IServiceProvider serviceProvider,
            IRequestContextProvider requestContextProvider,
            IApplicationRepository applicationRepository
        )
        {
            _sp = serviceProvider;
            _applicationRepository = applicationRepository;
            _context = requestContextProvider.Context;
        }

        public async Task<IFoundationClient> Create()
        {
            var application = await _applicationRepository.Get(_context.ApplicationId);

            var client = _sp.GetRequiredService<IFoundationClient>();

            client.Init(application.AdminHost, application.ShellHost, _context.LanguageCode, _context.Jwt, application.AdminJWT);

            return client;
        }
    }
}