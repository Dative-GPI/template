using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

using Microsoft.AspNetCore.HttpOverrides;
using System.Net.Http;

using XXXXX.CrossCutting.DI;
using XXXXX.Gateway.Core.DI;
using XXXXX.Gateway.API.DI;

namespace XXXXX.Gateway.API
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCore(Configuration);
            services.AddCrossCutting(Configuration);
            
            services.AddCustomContext();

            services.AddControllers();
            services.AddHealthChecks();

            services.AddHttpClient(string.Empty, c => { }).ConfigurePrimaryHttpMessageHandler(() =>
                 new HttpClientHandler
                 {
                     ClientCertificateOptions = ClientCertificateOption.Manual,
                     ServerCertificateCustomValidationCallback = (httpRequestMessage, cert, certChain, policyErrors) => true
                 }
            );

            services.AddAuthentication("Custom");

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "XXXXX.Gateway.API", Version = "v1" });
            });

            var proxyBuilder = services.AddReverseProxy();
            proxyBuilder.AddTransforms<FoundationRedirectTransform>();
            proxyBuilder.LoadFromConfig(Configuration.GetSection("ReverseProxy"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger(c =>
                {
                    c.RouteTemplate = "api/swagger/{documentname}/swagger.json";
                });

                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/api/swagger/v1/swagger.json", "Gateway v1");
                    c.RoutePrefix = "api/swagger";
                });
            }

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedProto
            });

            app.UseRouting();

            app.UseHealthChecks("/health");

            app.UseJWTAuthenticationMiddleware();
            app.UseAuthorization();

            app.UseClaimsToHeadersMiddleware();
            app.UseCustomContext();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                endpoints.MapReverseProxy(proxyPipeline =>
                {
                    proxyPipeline.UseSessionAffinity();
                    proxyPipeline.UseLoadBalancing();
                    proxyPipeline.UsePassiveHealthChecks();
                });
            });
        }
    }
}
