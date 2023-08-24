using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Foundation.Template.Shell.DI;
using Foundation.Template.CrossCutting.DI;

using Foundation.Template.Shell.Extensions;

using XXXXX.Shell.Kernel.DI;
using XXXXX.Context.Kernel.DI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddKernel(builder.Configuration);
builder.Services.AddShellTemplate(builder.Configuration);
builder.Services.AddContext(builder.Configuration);
builder.Services.AddCrossCutting(builder.Configuration);
builder.Services.AddHttpClient();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseShellTemplate();

app.MapControllers();
app.MapShellTemplateControllers(null);

app.Run();
