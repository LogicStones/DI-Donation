using API.Helpers;
using API.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;

namespace API.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILogger<Startup> logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        await context.Response.WriteAsync(new ResponseEntity()
                        {
                            error = true,
                            message = ResponseMessageKeys.serverError,
                            data = contextFeature.Error
                        }.ToString());
                    }
                    else
                    {
                        await context.Response.WriteAsync(new ResponseEntity()
                        {
                            error = true,
                            message = ResponseMessageKeys.serverError
                        }.ToString());
                    }
                });
            });
        }
    }
}