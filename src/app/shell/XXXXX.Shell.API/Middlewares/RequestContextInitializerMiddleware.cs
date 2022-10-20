using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using Microsoft.Extensions.DependencyInjection;

using XXXXX.Shell.API.Tools;
using XXXXX.Shell.Core.Models;

namespace XXXXX.Shell.API.Middlewares
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
                Guid organisationId = Guid.Empty;

                var hasOrganisationId = request.RouteValues.TryGetValue("organisationId", out var temp) && Guid.TryParse(temp.ToString(), out organisationId);

                var isAuthenticated = request.Headers.ContainsKey(HeaderNames.Authorization);

                return new RequestContext()
                {
                    ApplicationId = new Guid(request.Headers["X-Application-Id"].ToString()),
                    ActorId = new Guid(request.Headers["X-User-Id"].ToString()),
                    LanguageCode = request.Headers["Accept-Language"].ToString(),
                    Jwt = isAuthenticated ? request.Headers[HeaderNames.Authorization].ToString().Substring(7) : null,
                    OrganisationId = hasOrganisationId ? organisationId : null
                };
            };

            await _next(context);
        }
    }
}