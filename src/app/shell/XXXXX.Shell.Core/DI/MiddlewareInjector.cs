using Microsoft.Extensions.DependencyInjection;

using XXXXX.Shell.Core.Handlers;

namespace XXXXX.Shell.Core.DI
{
    public static class MiddlewareInjector
    {
        public static IServiceCollection AddMiddlewares(this IServiceCollection services)
        {
            services.AddScoped<PermissionsMiddleware>();
            
            return services;
        }
    }
}