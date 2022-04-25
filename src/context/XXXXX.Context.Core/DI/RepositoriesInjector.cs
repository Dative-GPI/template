using Microsoft.Extensions.DependencyInjection;


using XXXXX.Context.Core.Repositories;
using XXXXX.Domain.Repositories.Interfaces;

namespace XXXXX.Context.Core.DI
{
    public static class RepositoriesInjector
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IApplicationRepository, ApplicationRepository>();
            services.AddScoped<IPermissionRepository, PermissionRepository>();
            services.AddScoped<IOrganisationTypePermissionRepository, OrganisationTypePermissionRepository>();
            services.AddScoped<IRolePermissionRepository, RolePermissionRepository>();
            services.AddScoped<IRouteRepository, RouteRepository>();

            return services;
        }
    }
}