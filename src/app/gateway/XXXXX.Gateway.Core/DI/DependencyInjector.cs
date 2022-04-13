using AutoMapper;
using Bones.Flow;
using Microsoft.Extensions.DependencyInjection;
using XXXXX.Gateway.Core.Interfaces;
using XXXXX.Gateway.Core.Services;

namespace XXXXX.Gateway.Core.DI
{
    public static class DependencyInjector
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddFlow();

            services.AddAutoMapper(typeof(DependencyInjector).Assembly);

            services.AddScoped<IApplicationService, ApplicationService>();

            services.AddApplications();

            return services;
        }
    }
}