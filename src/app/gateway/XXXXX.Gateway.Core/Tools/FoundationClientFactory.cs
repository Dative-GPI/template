using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

using Foundation.Clients.Abstractions;
using XXXXX.Domain.Repositories.Interfaces;
using XXXXX.Gateway.Core.Abstractions;

namespace XXXXX.Gateway.Core.Tools
{
    public class FoundationClientFactory : IFoundationClientFactory
    {
        private IServiceProvider _sp;
        private IApplicationRepository _applicationRepository;
        private IRequestContextProvider _contextProvider;

        public FoundationClientFactory(
            IServiceProvider sp,
            IApplicationRepository applicationRepository,
            IRequestContextProvider contextProvider
        )
        {
            _sp = sp;
            _applicationRepository = applicationRepository;
            _contextProvider = contextProvider;
        }
        
        public async Task<IFoundationClient> Create(Guid applicationId, string languageCode, string jwt)
        {
            var client = _sp.GetRequiredService<IFoundationClient>();
            var app = await _applicationRepository.Get(applicationId);

            client.Init(app.AdminHost, app.ShellHost, languageCode, jwt, null);

            return client;
        }
        
        public async Task<IFoundationClient> Create()
        {
            var client = _sp.GetRequiredService<IFoundationClient>();
            var context = _contextProvider.Context;

            var app = await _applicationRepository.Get(context.ApplicationId);

            client.Init(app.AdminHost, app.ShellHost, context.LanguageCode, context.Jwt, null);

            return client;
        }
    }
}