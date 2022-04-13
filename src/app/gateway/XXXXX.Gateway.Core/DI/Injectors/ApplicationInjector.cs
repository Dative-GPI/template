using System;
using Bones.Flow;
using Bones.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using XXXXX.Gateway.Core.Handlers;
using XXXXX.Gateway.Core.Requests.Commands;

namespace XXXXX.Gateway.Core.DI
{
    public static class ApplicationInjector
    {
        public static IServiceCollection AddApplications(this IServiceCollection services)
        {
            services.AddScoped<CreateApplicationCommandHandler>();
            services.AddScoped<ICommandHandler<CreateApplicationCommand, IEntity<Guid>>>(sp =>
            {
                var pipeline = sp.GetPipelineFactory<CreateApplicationCommand, IEntity<Guid>>()
                    .Add<CreateApplicationCommandHandler>()
                    .Build();
            
                return pipeline;
            });

            services.AddScoped<RemoveApplicationCommandHandler>();
            services.AddScoped<ICommandHandler<RemoveApplicationCommand>>(sp => 
            {
                var pipeline = sp.GetPipelineFactory<RemoveApplicationCommand>()
                    .Add<RemoveApplicationCommandHandler>()
                    .Build();

                return pipeline;
            });

            return services;
        }
    } 
}