using Microsoft.AspNetCore.Builder;

using XXXXX.Gateway.API.Middlewares;

public static class ClaimsToHeadersMiddlewareExtension
{
    public static IApplicationBuilder UseClaimsToHeadersMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ClaimsToHeadersMiddleware>();
    }
}
