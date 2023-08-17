using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Foundation.Template.Shell.DI;
using Foundation.Template.Shell.Extensions;

using XXXXX.Shell.Core.DI;
using XXXXX.Context.Core.DI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCore(builder.Configuration);
builder.Services.AddShellTemplate(builder.Configuration);
builder.Services.AddContext(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseShellTemplate();

app.MapControllers();

app.Run();
