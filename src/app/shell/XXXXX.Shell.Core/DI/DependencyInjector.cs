using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Bones.Flow;
using AutoMapper;

namespace XXXXX.Shell.Core.DI
{
    public static class DependencyInjector
    {
        public static IServiceCollection AddCore(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddFlow();
            services.AddServices();
            services.AddMiddlewares();
            
            services.AddAutoMapper();

            services.AddRoutes();

            return services;
        }

        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(DependencyInjector).Assembly);

            return services;
        }
    }
}