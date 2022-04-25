using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

using Bones.Flow;

using XXXXX.Domain.Models;
using XXXXX.Admin.Core.Handlers;
using System;

namespace XXXXX.Admin.Core.DI
{
    public static class PermissionInjector
    {
        public static IServiceCollection AddPermissions(this IServiceCollection services)
        {
            services.AddScoped<PermissionsQueryHandler>();
            services.AddScoped<IQueryHandler<PermissionsQuery, IEnumerable<PermissionInfos>>>(sp =>
            {
                var pipeline = sp.GetPipelineFactory<PermissionsQuery, IEnumerable<PermissionInfos>>()
                    // .With<PermissionsMiddleware>()
                    .Add<PermissionsQueryHandler>()
                    .Build();

                return pipeline;
            });

            return services;
        }
    }
}