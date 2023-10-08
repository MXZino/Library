using System.Text.Json;
using Library.Errors;
using Library.Errors.Abstract.Base;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace Library.Configuration.Services.WebApplicationExtensions;

public static partial class WebApplicationExtensions
{
    public static void UseLibraryExceptionHandler(this WebApplication application)
    {
        application.UseExceptionHandler(builder =>
        {
            builder.Run(async context =>
            {
                var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();
                
                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";
                
                var errorDetails = CreateErrorDetails(context, exceptionHandlerFeature?.Error);
                
                await context.Response.WriteAsync(JsonSerializer.Serialize(errorDetails));
            });
        });
    }

    private static ErrorDetails CreateErrorDetails(HttpContext context, Exception exception)
    {
        if (exception is BaseAppException baseAppException)
        {
            context.Response.StatusCode = (int)baseAppException.StatusCode;
            
            return new ErrorDetails
            {
                Message = baseAppException.Message,
                TraceId = context.TraceIdentifier,
                InnerException = baseAppException.InnerException?.StackTrace,
                UrlPath = context.Request.GetFullRequestPath()
            };
        }
        
        return new ErrorDetails
        {
            Message = exception?.Message,
            TraceId = context.TraceIdentifier,
            InnerException = exception?.StackTrace,
            UrlPath = context.Request.GetFullRequestPath()
        };
    }
    
    private static string GetFullRequestPath(this HttpRequest request)
    {
        var scheme = request.Scheme;
        var host = request.Host;
        var pathBase = request.PathBase.Value;
        var path = request.Path.Value;
        var queryString = request.QueryString.Value;

        return $"{scheme}://{host}{pathBase}{path}{queryString}";
    }
}