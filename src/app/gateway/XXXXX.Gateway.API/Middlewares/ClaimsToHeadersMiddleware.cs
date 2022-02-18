using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using XXXXX.Domain.Abstractions;
using XXXXX.Domain.Models;

namespace XXXXX.Gateway.API.Middlewares
{
    public class ClaimsToHeadersMiddleware
    {
        private readonly RequestDelegate _next;
        private ILogger<ClaimsToHeadersMiddleware> _logger;
        private IServiceProvider _sp;

        public ClaimsToHeadersMiddleware(RequestDelegate next, ILogger<ClaimsToHeadersMiddleware> logger,
            IServiceProvider sp)
        {
            _next = next;
            _logger = logger;
            _sp = sp;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            using var scope = _sp.CreateScope();
            var claimFactory = scope.ServiceProvider.GetRequiredService<IClaimsFactory>();
            // Clean headers potentially used
            context.Request.Headers.Remove("X-User-Id");
            context.Request.Headers.Remove("X-Application-Id");
            
            if (context.Features.Get<IEndpointFeature>().Endpoint.Metadata.Any(m => m is AllowAnonymousAttribute))
            {
                await _next(context);
                return;
            }
            else
            {
                var claims = claimFactory.Get((ClaimsIdentity)context.User.Identity);

                context.Request.Headers.Add("X-Application-Id", claims.ApplicationId.ToString());
                context.Request.Headers.Add("X-User-Id", claims.UserId.ToString());
            }
        }
    }
}