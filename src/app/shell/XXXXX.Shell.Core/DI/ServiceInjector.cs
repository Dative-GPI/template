using Microsoft.Extensions.DependencyInjection;
using XXXXX.Shell.Core.Services;
using XXXXX.shell.Core.Interfaces;

namespace XXXXX.Shell.Core.DI
{
    public static class ServiceInjector
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IRouteService, RouteService>();

            return services;
        }
    }
}