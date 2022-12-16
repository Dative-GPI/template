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
            services.AddScoped<IPermissionCategoryService, PermissionCategoryService>();
            services.AddScoped<IRolePermissionService, RolePermissionService>();

            services.AddScoped<IPermissionAdminService, PermissionAdminService>();
            services.AddScoped<IPermissionAdminCategoryService, PermissionAdminCategoryService>();
            services.AddScoped<IRoleAdminPermissionService, RoleAdminPermissionService>();

            services.AddScoped<ITranslationService, TranslationService>();
            services.AddScoped<IApplicationTranslationService, ApplicationTranslationService>();

            return services;
        }
    }
}