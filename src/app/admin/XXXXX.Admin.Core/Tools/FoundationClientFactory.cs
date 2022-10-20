using System;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;

using Foundation.Clients.Abstractions;

using XXXXX.Domain.Repositories.Interfaces;

using XXXXX.Admin.Core.Abstractions;
using XXXXX.Admin.Core.Models;

namespace XXXXX.Admin.Core.Tools
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

            client.Init(application.AdminHost, application.ShellHost, _context.LanguageCode, _context.Jwt, _context.Jwt);

            return client;
        }
    }
}