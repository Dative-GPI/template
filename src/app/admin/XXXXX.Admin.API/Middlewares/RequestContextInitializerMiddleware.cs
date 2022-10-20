using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using Microsoft.Extensions.DependencyInjection;

using XXXXX.Admin.API.Tools;
using XXXXX.Admin.Core.Models;

namespace XXXXX.Admin.API.Middlewares
{
    public class RequestContextInitializerMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestContextInitializerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var request = context.Request;
            var provider = context.RequestServices.GetRequiredService<RequestContextProvider>();

            provider.Accessor = () =>
            {
                var isAuthenticated = request.Headers.ContainsKey(HeaderNames.Authorization);

                return new RequestContext()
                {
                    ApplicationId = new Guid(request.Headers["X-Application-Id"].ToString()),
                    ActorId = new Guid(request.Headers["X-User-Id"].ToString()),
                    LanguageCode = request.Headers["Accept-Language"].ToString(),
                    Jwt = isAuthenticated ? request.Headers[HeaderNames.Authorization].ToString().Substring(7) : null
                };
            };

            await _next(context);
        }
    }
}