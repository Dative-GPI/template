using System;
using System.Threading.Tasks;

using Bones.Exceptions;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace XXXXX.Shell.API.Middlewares
{
  public class CustomExceptionHandlerMiddleware
  {
        private readonly RequestDelegate _next;

        public CustomExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {   
            var controllerName = string.Empty;

            try
            {
                var controllerActionDescriptor = context
                    .GetEndpoint()
                    .Metadata
                    .GetMetadata<ControllerActionDescriptor>();

                controllerName = controllerActionDescriptor.ControllerName;
            }
            catch
            {
                // Do nothing
            }

            try
            {
                // Call the next delegate/middleware in the pipeline
                await _next(context);
            }
            catch (DbUpdateException ex)
            {
                context.Response.Clear();
                context.Response.StatusCode = 449; // retry
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync(string.IsNullOrWhiteSpace(controllerName) ? ex.Message : controllerName);
            }
            catch (UnauthorizedAccessException ex)
            {
                context.Response.Clear();
                context.Response.StatusCode = 403; // unauthorized
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync(string.IsNullOrWhiteSpace(controllerName) ? ex.Message : controllerName);
            }
            catch (ArgumentNullException ex)
            {
                context.Response.Clear();
                context.Response.StatusCode = 400; // bad request
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync(string.IsNullOrWhiteSpace(controllerName) ? ex.Message : controllerName);
            }
            catch (NullReferenceException ex)
            {
                context.Response.Clear();
                context.Response.StatusCode = 400; // bad request
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync(string.IsNullOrWhiteSpace(controllerName) ? ex.Message : controllerName);
            }
            catch (InvalidOperationException ex)
            {
                context.Response.Clear();
                context.Response.StatusCode = 404; // not found
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync(string.IsNullOrWhiteSpace(controllerName) ? ex.Message : controllerName);
            }
            catch (ArgumentException ex)
            {
                context.Response.Clear();
                context.Response.StatusCode = 409; // conflict
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync(string.IsNullOrWhiteSpace(controllerName) ? ex.Message : controllerName);
            }
            catch (Exception ex)
            {
                context.Response.Clear();
                context.Response.StatusCode = 500; // server error
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync(string.IsNullOrWhiteSpace(controllerName) ? ex.Message : controllerName);
            }

            return;
        }
    }
}