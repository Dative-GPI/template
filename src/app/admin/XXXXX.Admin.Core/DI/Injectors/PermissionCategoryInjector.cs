using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

using Bones.Flow;

using XXXXX.Domain.Models;
using XXXXX.Admin.Core.Handlers;

namespace XXXXX.Admin.Core.DI
{
    public static class PermissionCategoryInjector
    {
        public static IServiceCollection AddPermissionCategories(this IServiceCollection services)
        {
            services.AddScoped<PermissionCategoriesQueryHandler>();
            services.AddScoped<IQueryHandler<PermissionCategoriesQuery, IEnumerable<PermissionCategory>>>(sp =>
            {
                var pipeline = sp.GetPipelineFactory<PermissionCategoriesQuery, IEnumerable<PermissionCategory>>()
                    .With<PermissionsMiddleware>()
                    .Add<PermissionCategoriesQueryHandler>()
                    .Build();

                return pipeline;
            });

            return services;
        }
    }
}