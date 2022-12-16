using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using AutoMapper;

using Bones.Flow;
using XXXXX.Shell.Core.Abstractions;
using XXXXX.Shell.Core.Tools;

namespace XXXXX.Shell.Core.DI
{
    public static class DependencyInjector
    {
        public static IServiceCollection AddCore(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddFlow();
            services.AddServices();
            services.AddMiddlewares();

            services.AddPermissions();
            services.AddOrganisationPermissions();
            services.AddRolePermissions();

            services.AddRoutes();
            
            services.AddAutoMapper();

            services.AddScoped<IPermissionProvider, PermissionProvider>();

            return services;
        }

        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(DependencyInjector).Assembly);

            return services;
        }
    }
}