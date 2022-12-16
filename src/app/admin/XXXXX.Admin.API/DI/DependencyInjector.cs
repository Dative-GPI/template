using Microsoft.Extensions.DependencyInjection;

using XXXXX.Admin.API.Tools;
using XXXXX.Admin.Core.Abstractions;

namespace XXXXX.Admin.API.DI
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