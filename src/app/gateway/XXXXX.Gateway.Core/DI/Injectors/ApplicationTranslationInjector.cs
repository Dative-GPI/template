using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Bones.Flow;

using XXXXX.Domain.Models;
using XXXXX.Gateway.Core.Handlers;

namespace XXXXX.Gateway.Core.DI
{
    public static class ApplicationTranslationInjector
    {
        public static IServiceCollection AddApplicationTranslations(this IServiceCollection services)
        {
            services.AddScoped<ApplicationTranslationsQueryHandler>();
            services.AddScoped<IQueryHandler<ApplicationTranslationsQuery, IEnumerable<ApplicationTranslation>>>(sp =>
            {
                var pipeline = sp.GetPipelineFactory<ApplicationTranslationsQuery, IEnumerable<ApplicationTranslation>>()
                    .Add<ApplicationTranslationsQueryHandler>()
                    .Build();
            
                return pipeline;
            });

            return services;
        }
    } 
}