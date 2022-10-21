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
            services.AddScoped<IRouteRepository, RouteRepository>();
            services.AddScoped<IImageRepository, ImageRepository>();

            services.AddScoped<IPermissionRepository, PermissionRepository>();
            services.AddScoped<IPermissionCategoryRepository, PermissionCategoryRepository>();
            services.AddScoped<IOrganisationTypePermissionRepository, OrganisationTypePermissionRepository>();
            services.AddScoped<IRolePermissionRepository, RolePermissionRepository>();
            services.AddScoped<IPermissionAdminRepository, PermissionAdminRepository>();
            services.AddScoped<IPermissionAdminCategoryRepository, PermissionAdminCategoryRepository>();
            services.AddScoped<IRoleAdminPermissionRepository, RoleAdminPermissionRepository>();

            services.AddScoped<IApplicationTranslationRepository, ApplicationTranslationRepository>();
            services.AddScoped<ITranslationRepository, TranslationRepository>();

            return services;
        }
    }
}