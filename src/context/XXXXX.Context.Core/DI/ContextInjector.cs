using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Microsoft.EntityFrameworkCore;

using Bones.Flow;

namespace XXXXX.Context.Core.DI
{
    public static class DependencyInjector
    {
        public static IServiceCollection AddContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRepositories();
            
            services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(configuration.GetConnectionString("PGSQL")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}