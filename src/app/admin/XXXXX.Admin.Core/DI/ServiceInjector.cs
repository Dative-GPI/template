using Microsoft.Extensions.DependencyInjection;
using XXXXX.Admin.Core.Services;
using XXXXX.Admin.Core.Interfaces;

namespace XXXXX.Admin.Core.DI
{
    public static class ServiceInjector
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IRouteService, RouteService>();
            services.AddScoped<IOrganisationTypePermissionService, OrganisationTypePermissionService>();
            services.AddScoped<IPermissionService, PermissionService>();
            services.AddScoped<IRolePermissionService, RolePermissionService>();

            return services;
        }
    }
}