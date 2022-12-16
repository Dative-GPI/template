using System;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;

using Yarp.ReverseProxy.Transforms;
using Yarp.ReverseProxy.Transforms.Builder;

using XXXXX.Domain.Abstractions;
using XXXXX.Domain.Repositories.Interfaces;

namespace XXXXX.Gateway.API
{
    public class FoundationRedirectTransform : ITransformProvider
    {
        public void Apply(TransformBuilderContext context)
        {
            context.AddRequestTransform(async requestContext =>
            {
                if (requestContext.Path.StartsWithSegments("/api/core"))
                {
                    var request = requestContext.HttpContext.Request;
                    var applicationRepository = requestContext.HttpContext.RequestServices.GetRequiredService<IApplicationRepository>();
                    var claimsFactory = requestContext.HttpContext.RequestServices.GetRequiredService<IClaimsFactory>();

                    var token = "";

                    var bearer = request.Headers[HeaderNames.Authorization];
                    if (!string.IsNullOrWhiteSpace(bearer))
                    {
                        token = bearer.ToString().Substring("Bearer ".Length);
                    } else {
                        token = request.Query["token"];
                        request.Headers.Add(HeaderNames.Authorization, "Bearer " + token);
                    }

                    var tokenHandler = new JwtSecurityTokenHandler().ReadJwtToken(token);

                    var claims = claimsFactory.Get(tokenHandler.Claims);
                    Guid applicationId = claims.ApplicationId;

                    var application = await applicationRepository.Get(applicationId);

                    var newUri = new UriBuilder();
                    newUri.Scheme = request.Scheme;
                    newUri.Host = application.ShellHost;
                    if (request.Host.Port.HasValue) newUri.Port = request.Host.Port.Value;
                    newUri.Path = request.Path.ToUriComponent().Replace("/api/core", "/api");
                    newUri.Query = request.QueryString.ToUriComponent();

                    // TODO: Organisation header missing !!!
                    requestContext.ProxyRequest.RequestUri = newUri.Uri;
                }
            });
        }

        public void ValidateCluster(TransformClusterValidationContext context)
        {
        }

        public void ValidateRoute(TransformRouteValidationContext context)
        {
        }
    }
}