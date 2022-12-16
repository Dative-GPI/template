using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

using Bones.Flow;
using Bones.Repository.Interfaces;

using XXXXX.Domain.Models;
using XXXXX.Shell.Core.Handlers;

namespace XXXXX.Shell.Core.DI
{
    public static class OrganisationPermissionInjector
    {
        public static IServiceCollection AddOrganisationPermissions(this IServiceCollection services)
        {
            services.AddScoped<OrganisationPermissionsQueryHandler>();
            services.AddScoped<IQueryHandler<OrganisationPermissionsQuery, IEnumerable<PermissionInfos>>>(sp =>
            {
                var pipeline = sp.GetPipelineFactory<OrganisationPermissionsQuery, IEnumerable<PermissionInfos>>()
                    .With<PermissionsMiddleware>()
                    .Add<OrganisationPermissionsQueryHandler>()
                    .Build();

                return pipeline;
            });

            return services;
        }
    }
}