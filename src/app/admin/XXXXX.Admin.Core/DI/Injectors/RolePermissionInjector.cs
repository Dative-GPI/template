using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

using Bones.Flow;

using XXXXX.Domain.Models;
using XXXXX.Admin.Core.Handlers;

namespace XXXXX.Admin.Core.DI
{
    public static class RolePermissionInjector
    {
        public static IServiceCollection AddRolePermissions(this IServiceCollection services)
        {
            services.AddScoped<RolePermissionsQueryHandler>();
            services.AddScoped<IQueryHandler<RolePermissionsQuery, IEnumerable<PermissionInfos>>>(sp =>
            {
                var pipeline = sp.GetPipelineFactory<RolePermissionsQuery, IEnumerable<PermissionInfos>>()
                    .With<PermissionsMiddleware>()
                    .Add<RolePermissionsQueryHandler>()
                    .Build();

                return pipeline;
            });


            services.AddScoped<UpdateRolePermissionsCommandHandler>();
            services.AddScoped<ICommandHandler<UpdateRolePermissionsCommand>>(sp =>
            {
                var pipeline = sp.GetPipelineFactory<UpdateRolePermissionsCommand>()
                    .Add<PermissionsMiddleware>()
                    .Add<UpdateRolePermissionsCommandHandler>()
                    .Build();

                return pipeline;
            });

            return services;
        }
    }
}