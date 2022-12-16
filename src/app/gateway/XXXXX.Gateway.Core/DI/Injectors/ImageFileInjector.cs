using Bones.Flow;

using Microsoft.Extensions.DependencyInjection;

using XXXXX.Domain.Models;
using XXXXX.Gateway.Core.Handlers;

namespace XXXXX.Gateway.Core.DI
{
    public static class ImageInjector
    {
        public static IServiceCollection AddImages(this IServiceCollection services)
        {
            services.AddScoped<RawImageQueryHandler>();
            services.AddScoped<IQueryHandler<RawImageQuery, byte[]>>(sp =>
            {
                var pipeline = sp.GetPipelineFactory<RawImageQuery, byte[]>()
                    .Add<RawImageQueryHandler>()
                    .Build();

                return pipeline;
            });


            services.AddScoped<ThumbnailImageQueryHandler>();
            services.AddScoped<IQueryHandler<ThumbnailImageQuery, byte[]>>(sp =>
            {
                var pipeline = sp.GetPipelineFactory<ThumbnailImageQuery, byte[]>()
                    .Add<ThumbnailImageQueryHandler>()
                    .Build();

                return pipeline;
            });

            return services;
        }
    }
}