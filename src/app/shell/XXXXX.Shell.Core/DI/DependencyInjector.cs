using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Bones.Flow;

using Foundation.Template.Shell.Abstractions;

using XXXXX.Shell.Core.Services;

namespace XXXXX.Shell.Core.DI
{
    public static class DependencyInjector
    {
        public static IServiceCollection AddCore(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddFlow();

            services.AddScoped<IRoutesProvider, RoutesProvider>();

            services.AddAutoMapper(typeof(DependencyInjector).Assembly);

            return services;
        }
    }
}