using Microsoft.Extensions.DependencyInjection;

using XXXXX.Shell.API.Tools;
using XXXXX.Shell.Core.Abstractions;

namespace XXXXX.Shell.API.DI
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