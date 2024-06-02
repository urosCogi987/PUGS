using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TaxiApp.Kernel.Exeptions;

namespace TaxiApp.WebApi.Middlewares
{
    public class AppExceptionHandler(ILogger<AppExceptionHandler> logger) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext,
                                                    Exception exception,
                                                    CancellationToken cancellationToken)
        {
            var result = new ProblemDetails();
            switch (exception)
            {
                case ArgumentNullException argumentNullException:
                    result = new ProblemDetails
                    {
                        Status = (int)HttpStatusCode.NotFound,
                        Detail = argumentNullException.Message,
                    };
                    break;
                case InvalidRequestException invalidRequestException:
                    result = new ProblemDetails
                    {
                        Status = (int)HttpStatusCode.BadRequest,
                        Detail = invalidRequestException.Message,
                    };
                    break;
                default:
                    result = new ProblemDetails
                    {
                        Status = (int)HttpStatusCode.InternalServerError,
                        Detail = "An unexpected error occurred"
                    };
                    logger.LogError($"\nStatus: {(int)HttpStatusCode.InternalServerError}\n" +
                                    $"Type: {exception.GetType().Name}\n" +
                                    $"Detail: {exception.Message}\n" +
                                    $"Instance: {httpContext.Request.Method} {httpContext.Request.Path}");
                    break;
            }

            httpContext.Response.StatusCode = (int)result.Status;
            await httpContext.Response.WriteAsJsonAsync(result, cancellationToken: cancellationToken);
            return true;
        }
    }
}
