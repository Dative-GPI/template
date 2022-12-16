using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Bones.Flow;
using AutoMapper;

using XXXXX.Admin.Core.Abstractions;
using XXXXX.Admin.Core.Tools;

namespace XXXXX.Admin.Core.DI
{
    public static class DependencyInjector
    {
        public static IServiceCollection AddCore(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddFlow();
            services.AddServices();
            services.AddMiddlewares();
            services.AddAutoMapper();

            services.AddPermissions();
            services.AddPermissionCategories();
            services.AddOrganisationTypePermissions();
            services.AddRolePermissions();

            services.AddPermissionAdmins();
            services.AddPermissionAdminCategories();
            services.AddRoleAdminPermissions();

            services.AddRoutes();
            services.AddTranslations();
            services.AddApplicationTranslations();

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