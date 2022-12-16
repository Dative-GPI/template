using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

using XXXXX.Context.Core.DI;
using XXXXX.Admin.Core.DI;
using XXXXX.CrossCutting.DI;
using XXXXX.Admin.API.DI;

namespace XXXXX.Admin.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddContext(Configuration);
            services.AddCore(Configuration);
            services.AddCrossCutting(Configuration);

            services.AddCustomContext();

            services.AddHttpClient(string.Empty, c => { }).ConfigurePrimaryHttpMessageHandler(() =>
                 new HttpClientHandler
                 {
                     ClientCertificateOptions = ClientCertificateOption.Manual,
                     ServerCertificateCustomValidationCallback = (httpRequestMessage, cert, certChain, policyErrors) => true
                 }
            );

            services.AddHttpClient();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "XXXXX.Admin.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "XXXXX.Admin.API v1"));
            }

            app.UseRouting();

            app.UseCustomExceptionHandler();
            app.UseCustomContext();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
