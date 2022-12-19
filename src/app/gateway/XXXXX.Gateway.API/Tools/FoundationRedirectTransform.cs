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
using System.Collections.Generic;
using System.Linq;

namespace XXXXX.Gateway.API
{
    public class FoundationRedirectTransform : ITransformProvider
    {
        public void Apply(TransformBuilderContext context)
        {
            context.AddRequestTransform(async requestContext =>
            {
                if (requestContext.Path.StartsWithSegments("/api/core/organisations"))
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
                    
                    var pathArray = request.Path.ToUriComponent().Split('/', StringSplitOptions.RemoveEmptyEntries);
                    var pathList = new List<string>() { "api" };
                    pathList.AddRange(pathArray.Skip(4)); // 4 pour api, core, organisations et organisationId
                    newUri.Path = String.Join('/', pathList.ToArray()); 

                    newUri.Query = request.QueryString.ToUriComponent();

                    var organisationIdParam = request.RouteValues["organisationId"];
                    var organisationId = Guid.Parse(organisationIdParam.ToString());
                    requestContext.ProxyRequest.Headers.Add("X-Organisation-Id", organisationId.ToString());

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