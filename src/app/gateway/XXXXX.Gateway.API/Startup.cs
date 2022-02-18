using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

using XXXXX.Domain.Settings;
using Microsoft.AspNetCore.HttpOverrides;
using System.Net.Http;
using XXXXX.CrossCutting.DI;

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
            var jwtSettings = Configuration.GetSection("Jwt").Get<JwtSettings>();

            services.AddCrossCutting(Configuration);

            services.AddControllers();

            services.AddHttpClient(string.Empty, c => {}).ConfigurePrimaryHttpMessageHandler(() =>
                new HttpClientHandler
                {
                    ClientCertificateOptions = ClientCertificateOption.Manual,
                    ServerCertificateCustomValidationCallback = (httpRequestMessage, cert, certChain, policyErrors) => true
                }
            );

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "XXXXX.Gateway.API", Version = "v1" });
            });

            var proxyBuilder = services.AddReverseProxy();
            proxyBuilder.LoadFromConfig(Configuration.GetSection("ReverseProxy"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "XXXXX.Gateway.API v1"));
            }
            
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedProto
            });

            app.UseRouting();

            app.UseJWTAuthenticationMiddleware();
            app.UseClaimsToHeadersMiddleware();

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
