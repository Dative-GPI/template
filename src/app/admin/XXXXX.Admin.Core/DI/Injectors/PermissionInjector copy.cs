using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

using Bones.Flow;

using XXXXX.Domain.Models;
using XXXXX.Admin.Core.Handlers;
using System;

namespace XXXXX.Admin.Core.DI
{
    public static class OrganisationTypePermissionInjector
    {
        public static IServiceCollection AddOrganisationTypePermissions(this IServiceCollection services)
        {
            services.AddScoped<OrganisationTypePermissionsQueryHandler>();
            services.AddScoped<IQueryHandler<OrganisationTypePermissionsQuery, IEnumerable<PermissionInfos>>>(sp =>
            {
                var pipeline = sp.GetPipelineFactory<OrganisationTypePermissionsQuery, IEnumerable<PermissionInfos>>()
                    // .With<PermissionsMiddleware>()
                    .Add<OrganisationTypePermissionsQueryHandler>()
                    .Build();

                return pipeline;
            });


            services.AddScoped<UpdateOrganisationTypePermissionsCommandHandler>();
            services.AddScoped<ICommandHandler<UpdateOrganisationTypePermissionsCommand>>(sp =>
            {
                var pipeline = sp.GetPipelineFactory<UpdateOrganisationTypePermissionsCommand>()
                    // .Add<PermissionsMiddleware>()
                    .Add<UpdateOrganisationTypePermissionsCommandHandler>()
                    .Build();

                return pipeline;
            });

            return services;
        }
    }
}