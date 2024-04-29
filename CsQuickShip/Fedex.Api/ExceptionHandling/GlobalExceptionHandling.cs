using Fedex.Domain.ConfigurationModel;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Threading.Tasks;

namespace Fedex.Api.ExceptionHandling;
// You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
public class GlobalExceptionHandling
{
    private readonly RequestDelegate _next;

    public GlobalExceptionHandling(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {

            await Handler(httpContext, ex);
        }

    }

    private async static Task Handler(HttpContext httpContext, Exception exception)
    {
        httpContext.Response.StatusCode = (int)StatusCodes.Status500InternalServerError;
        httpContext.Response.ContentType = "application/json";
        ErrorDetails errorDetails = new() { Message = exception.Message };

        (errorDetails.StatusCode, errorDetails.ExceptionType) = exception switch
        {
            OperationCanceledException => (StatusCodes.Status408RequestTimeout, nameof(OperationCanceledException)),
            NotImplementedException => (StatusCodes.Status501NotImplemented, nameof(NotImplementedException)),
            ArgumentNullException => (StatusCodes.Status400BadRequest, nameof(ArgumentException)),
            _ => throw new NotImplementedException(),
        };
       
        await httpContext.Response.WriteAsJsonAsync(errorDetails);
    }
}



// Extension method used to add the middleware to the HTTP request pipeline.
public static class GlobalExceptionHandlingExtensions
{
    public static IApplicationBuilder UseGlobalExceptionHandling(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<GlobalExceptionHandling>();
    }
}
