using Microsoft.Extensions.DependencyInjection;


namespace XXXXX.Shell.Core.DI
{
    public static class MiddlewareInjector
    {
        public static IServiceCollection AddMiddlewares(this IServiceCollection services)
        {
            //services.AddScoped<PermissionsMiddleware>();
            
            return services;
        }
    }
}