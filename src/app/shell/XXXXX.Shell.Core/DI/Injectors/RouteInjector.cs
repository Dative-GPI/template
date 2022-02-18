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
            services.AddScoped<DrawerRoutesQueryHandler>();

            services.AddScoped<IQueryHandler<DrawerRoutesQuery, IEnumerable<DrawerRouteInfos>>>(sp =>
            {
                var pipeline = sp.GetPipelineFactory<DrawerRoutesQuery, IEnumerable<DrawerRouteInfos>>()
                    // .With<PermissionsMiddleware>()
					.Add<DrawerRoutesQueryHandler>()
                    .Build();

                return pipeline;
            });

            return services;
        }
    }
}