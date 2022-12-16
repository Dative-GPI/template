using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

using Bones.Flow;

using XXXXX.Domain.Models;
using XXXXX.Admin.Core.Handlers;

namespace XXXXX.Admin.Core.DI
{
    public static class PermissionAdminCategoryInjector
    {
        public static IServiceCollection AddPermissionAdminCategories(this IServiceCollection services)
        {
            services.AddScoped<PermissionAdminCategoriesQueryHandler>();
            services.AddScoped<IQueryHandler<PermissionAdminCategoriesQuery, IEnumerable<PermissionAdminCategory>>>(sp =>
            {
                var pipeline = sp.GetPipelineFactory<PermissionAdminCategoriesQuery, IEnumerable<PermissionAdminCategory>>()
                    .With<PermissionsMiddleware>()
                    .Add<PermissionAdminCategoriesQueryHandler>()
                    .Build();

                return pipeline;
            });

            return services;
        }
    }
}