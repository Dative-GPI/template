using System;
using System.Collections.Generic;

using Bones.Flow;
using Bones.Repository.Interfaces;

using Microsoft.Extensions.DependencyInjection;

using XXXXX.Domain.Models;
using XXXXX.Shell.Core.Handlers;

namespace XXXXX.Shell.Core.DI
{
    public static class RouteInjector
    {
        public static IServiceCollection AddRoutes(this IServiceCollection services)
        {
            services.AddScoped<RoutesQueryHandler>();

            services.AddScoped<IQueryHandler<RoutesQuery, IEnumerable<RouteInfos>>>(sp =>
            {
                var pipeline = sp.GetPipelineFactory<RoutesQuery, IEnumerable<RouteInfos>>()
                    // .With<PermissionsMiddleware>()
					.Add<RoutesQueryHandler>()
                    .Build();

                return pipeline;
            });

            return services;
        }
    }
}