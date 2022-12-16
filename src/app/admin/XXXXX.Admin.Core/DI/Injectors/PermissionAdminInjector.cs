using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

using Bones.Flow;

using XXXXX.Domain.Models;
using XXXXX.Admin.Core.Handlers;

namespace XXXXX.Admin.Core.DI
{
    public static class PermissionAdminInjector
    {
        public static IServiceCollection AddPermissionAdmins(this IServiceCollection services)
        {
            services.AddScoped<PermissionAdminsQueryHandler>();
            services.AddScoped<IQueryHandler<PermissionAdminsQuery, IEnumerable<PermissionAdminInfos>>>(sp =>
            {
                var pipeline = sp.GetPipelineFactory<PermissionAdminsQuery, IEnumerable<PermissionAdminInfos>>()
                    .With<PermissionsMiddleware>()
                    .Add<PermissionAdminsQueryHandler>()
                    .Build();

                return pipeline;
            });

            return services;
        }
    }
}