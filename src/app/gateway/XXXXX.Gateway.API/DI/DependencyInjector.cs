using Microsoft.Extensions.DependencyInjection;

using XXXXX.Gateway.API.Tools;
using XXXXX.Gateway.Core.Abstractions;

namespace XXXXX.Gateway.API.DI
{
    public static class DependencyInjector
    {
        public static IServiceCollection AddCustomContext(this IServiceCollection services)
        {
            services.AddScoped<RequestContextProvider>();
            services.AddScoped<IRequestContextProvider>(sp 
                => sp.GetRequiredService<RequestContextProvider>());

            return services;
        }
    }
}