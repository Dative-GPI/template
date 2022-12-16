using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

using Bones.Flow;

using XXXXX.Context.Core.Configurations;
using XXXXX.Context.Core.Abstractions;
using XXXXX.Context.Core.Services;

namespace XXXXX.Context.Core.DI
{
    public static class DependencyInjector
    {
        public static IServiceCollection AddContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ImageConfiguration>(configuration.GetSection("Image"));

            services.AddRepositories();

            services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("PGSQL"));
                options.EnableSensitiveDataLogging();
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IImageHelper, ImageHelper>();
            services.AddScoped<IBinaryStorage, BinaryStorage>();

            return services;
        }
    }
}