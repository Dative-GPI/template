using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;

using XXXXX.Domain.Models;

namespace xxxxx.Gateway.API.Middlewares
{
    public class JWTAuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        private IServiceProvider _serviceProvider;
        private HttpClient _httpClient;
        private ILogger<JWTAuthenticationMiddleware> _logger;

        public JWTAuthenticationMiddleware(RequestDelegate next, IServiceProvider serviceProvider, ILogger<JWTAuthenticationMiddleware> logger, HttpClient httpClient)
        {
            _next = next;
            _serviceProvider = serviceProvider;
            _logger = logger;
            _httpClient = httpClient;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            _logger.LogTrace("JWT authentication middleware start");

            if (context.Features.Get<IEndpointFeature>().Endpoint.Metadata.Any(m => m is AllowAnonymousAttribute))
            {
                await _next(context);
            }
            else
            {
                var handler = new HttpClientHandler();
                handler.ClientCertificateOptions = ClientCertificateOption.Manual;
                handler.ServerCertificateCustomValidationCallback =
                    (httpRequestMessage, cert, cetChain, policyErrors) =>
                {
                    return true;
                };

                var client = new HttpClient(handler);
                var url = "https://foundation-admin.localhost/api/v1/users/current";

                var bearer = context.Request.Headers[HeaderNames.Authorization];
                client.DefaultRequestHeaders.Add("Authorization", bearer.ToString());

                var response = await client.GetAsync(url);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    _logger.LogTrace("JWT authentication middleware Authentication succeed");

                    var toRead = bearer.ToString().Substring("Bearer ".Length);
                    var token = new JwtSecurityTokenHandler().ReadJwtToken(toRead);

                    ClaimsIdentity identity = new ClaimsIdentity(token.Claims, "Custom");

                    context.User = new ClaimsPrincipal(identity);

                    _logger.LogTrace("JWT authentication middleware Authentication terminated");
                    await _next(context);
                }
                else
                {
                    _logger.LogError("Unable to verify JWT token : {response}", response.ReasonPhrase);
                    context.Response.StatusCode = 401;
                }
            }
        }
    }
}