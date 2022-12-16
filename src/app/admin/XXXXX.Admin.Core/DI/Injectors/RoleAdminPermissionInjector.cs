using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

using Bones.Flow;

using XXXXX.Domain.Models;
using XXXXX.Admin.Core.Handlers;

namespace XXXXX.Admin.Core.DI
{
    public static class RoleAdminPermissionInjector
    {
        public static IServiceCollection AddRoleAdminPermissions(this IServiceCollection services)
        {
            services.AddScoped<RoleAdminPermissionsQueryHandler>();
            services.AddScoped<IQueryHandler<RoleAdminPermissionsQuery, IEnumerable<PermissionAdminInfos>>>(sp =>
            {
                var pipeline = sp.GetPipelineFactory<RoleAdminPermissionsQuery, IEnumerable<PermissionAdminInfos>>()
                    .With<PermissionsMiddleware>()
                    .Add<RoleAdminPermissionsQueryHandler>()
                    .Build();

                return pipeline;
            });


            services.AddScoped<UpdateRoleAdminPermissionsCommandHandler>();
            services.AddScoped<ICommandHandler<UpdateRoleAdminPermissionsCommand>>(sp =>
            {
                var pipeline = sp.GetPipelineFactory<UpdateRoleAdminPermissionsCommand>()
                    .Add<PermissionsMiddleware>()
                    .Add<UpdateRoleAdminPermissionsCommandHandler>()
                    .Build();

                return pipeline;
            });

            return services;
        }
    }
}