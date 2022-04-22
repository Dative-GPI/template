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


            services.AddScoped<PermissionOrganisationTypesQueryHandler>();
            services.AddScoped<IQueryHandler<PermissionOrganisationTypesQuery, IEnumerable<PermissionInfos>>>(sp =>
            {
                var pipeline = sp.GetPipelineFactory<PermissionOrganisationTypesQuery, IEnumerable<PermissionInfos>>()
                    // .With<PermissionsMiddleware>()
                    .Add<PermissionOrganisationTypesQueryHandler>()
                    .Build();

                return pipeline;
            });


            services.AddScoped<UpdatePermissionOrganisationTypesCommandHandler>();
            services.AddScoped<ICommandHandler<UpdatePermissionOrganisationTypesCommand>>(sp =>
            {
                var pipeline = sp.GetPipelineFactory<UpdatePermissionOrganisationTypesCommand>()
                    // .Add<PermissionsMiddleware>()
                    .Add<UpdatePermissionOrganisationTypesCommandHandler>()
                    .Build();

                return pipeline;
            });

            return services;
        }
    }
}