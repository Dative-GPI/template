using Microsoft.Extensions.DependencyInjection;


namespace XXXXX.Admin.Core.DI
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