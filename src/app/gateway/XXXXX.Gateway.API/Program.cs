using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Foundation.Template.Gateway.DI;
using Foundation.Template.Gateway.Extensions;

using XXXXX.Gateway.Core.DI;
using XXXXX.Context.Core.DI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCore(builder.Configuration);
builder.Services.AddGatewayTemplate();
builder.Services.AddContext(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseGatewayTemplate();

app.MapControllers();

app.Run();
