using System;
using System.Collections.Generic;

using Bones.Flow;
using Bones.Repository.Interfaces;

using Microsoft.Extensions.DependencyInjection;

using XXXXX.Domain.Models;
using XXXXX.Admin.Core.Handlers;
using XXXXX.Admin.Core.Requests;

namespace XXXXX.Admin.Core.DI
{
    public static class ApplicationTranslationInjector
    {
        public static IServiceCollection AddApplicationTranslations(this IServiceCollection services)
        {
            services.AddScoped<ApplicationTranslationsQueryHandler>();
            services.AddScoped<IQueryHandler<ApplicationTranslationsQuery, IEnumerable<ApplicationTranslation>>>(sp =>
            {
                var pipeline = sp.GetPipelineFactory<ApplicationTranslationsQuery, IEnumerable<ApplicationTranslation>>()
                    .With<PermissionsMiddleware>()
					.Add<ApplicationTranslationsQueryHandler>()
                    .Build();

                return pipeline;
            });

            
            services.AddScoped<UpdateApplicationTranslationsCommandHandler>();
            services.AddScoped<ICommandHandler<UpdateApplicationTranslationCommand>>(sp => 
            {
                var pipeline = sp.GetPipelineFactory<UpdateApplicationTranslationCommand>()
                    .Add<PermissionsMiddleware>()
                    .Add<UpdateApplicationTranslationsCommandHandler>()
                    .Build();
                
                return pipeline;
            });

            return services;
        }
    }
}