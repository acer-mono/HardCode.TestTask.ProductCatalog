using System.Net;
using HardCode.TestTask.ProductCatalog.Entities.Exceptions.Base;
using Microsoft.AspNetCore.Diagnostics;
using InvalidOperationException = System.InvalidOperationException;

namespace HardCode.TestTask.ProductCatalog.Extensions;

public static class ExceptionMiddlewareExtensions
{
    public static void ConfigureExceptionHandler(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";
                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature != null)
                {
                    context.Response.StatusCode = contextFeature.Error switch
                    {
                        NotFoundException => StatusCodes.Status404NotFound,
                        InvalidOperationException => StatusCodes.Status400BadRequest,
                        _ => StatusCodes.Status500InternalServerError
                    };
                    context.Response.ContentType = "text/plain";
                    await context.Response.WriteAsync(contextFeature.Error.Message);
                }
            });
        });
    }
}