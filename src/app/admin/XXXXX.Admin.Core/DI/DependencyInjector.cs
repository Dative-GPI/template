using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Bones.Flow;
using AutoMapper;

namespace XXXXX.Admin.Core.DI
{
    public static class DependencyInjector
    {
        public static IServiceCollection AddCore(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddFlow();

            services.AddAutoMapper(typeof(DependencyInjector).Assembly);

            return services;
        }
    }
}