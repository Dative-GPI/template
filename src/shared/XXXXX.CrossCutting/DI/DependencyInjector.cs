using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Foundation.Clients.DI;

using XXXXX.Context.Core.DI;
using XXXXX.CrossCutting.Services;
using XXXXX.Domain.Abstractions;

namespace XXXXX.CrossCutting.DI
{
    public static class DependencyInjector
    {
        public static IServiceCollection AddCrossCutting(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddContext(configuration);

            services.AddSingleton<IClaimsFactory, ClaimsFactory>();

            services.AddFoundationClients(configuration);

            return services;
        }
    }
}