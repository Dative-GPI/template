using Microsoft.AspNetCore.Builder;

using XXXXX.Admin.API.Middlewares;

public static class RequestContextInitializerMiddlewareExtension
{
    public static IApplicationBuilder UseCustomContext(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<RequestContextInitializerMiddleware>();
    }
}