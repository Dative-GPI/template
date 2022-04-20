using Microsoft.Extensions.DependencyInjection;
using XXXXX.Admin.Core.Services;
using XXXXX.admin.Core.Interfaces;

namespace XXXXX.Admin.Core.DI
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