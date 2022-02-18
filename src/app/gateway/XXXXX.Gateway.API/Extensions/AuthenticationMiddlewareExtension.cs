using Microsoft.AspNetCore.Builder;

using xxxxx.Gateway.API.Middlewares;

public static class AuthenticationMiddlewareExtension
{
    public static IApplicationBuilder UseJWTAuthenticationMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<JWTAuthenticationMiddleware>();
    }
}
