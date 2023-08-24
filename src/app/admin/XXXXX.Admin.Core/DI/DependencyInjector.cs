using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Bones.Flow;

using XXXXX.Admin.Core.Services;
using Foundation.Template.Admin.Abstractions;

namespace XXXXX.Admin.Core.DI
{
    public static class DependencyInjector
    {
        public static IServiceCollection AddCore(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddFlow();

            services.AddScoped<IRoutesProvider, RoutesProvider>();
            services.AddScoped<IActionsProvider, ActionsProvider>();

            services.AddAutoMapper(typeof(DependencyInjector).Assembly);

            return services;
        }
    }
}