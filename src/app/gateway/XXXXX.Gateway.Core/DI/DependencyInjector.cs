using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;

using Bones.Flow;

using Foundation.Clients.DI;
using XXXXX.Gateway.Core.Interfaces;
using XXXXX.Gateway.Core.Services;
using XXXXX.Gateway.Core.Abstractions;
using XXXXX.Gateway.Core.Tools;

namespace XXXXX.Gateway.Core.DI
{
    public static class DependencyInjector
    {
        public static IServiceCollection AddCore(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddFlow();
            services.AddFoundationClients(configuration);

            services.AddAutoMapper(typeof(DependencyInjector).Assembly);

            services.AddScoped<IFoundationClientFactory, FoundationClientFactory>();
            services.AddScoped<ITranslationProvider, TranslationProvider>();

            services.AddScoped<IApplicationService, ApplicationService>();
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<IApplicationTranslationService, ApplicationTranslationService>();

            services.AddApplications();
            services.AddImages();
            services.AddApplicationTranslations();

            return services;
        }
    }
}