using Microsoft.Extensions.DependencyInjection;

using XXXXX.Shell.Core.Services;
using XXXXX.Shell.Core.Interfaces;

namespace XXXXX.Shell.Core.DI
{
    public static class ServiceInjector
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IRouteService, RouteService>();
            
            services.AddScoped<IPermissionService, PermissionService>();
            services.AddScoped<IOrganisationPermissionService, OrganisationPermissionService>();
            services.AddScoped<IRolePermissionService, RolePermissionService>();

            return services;
        }
    }
}