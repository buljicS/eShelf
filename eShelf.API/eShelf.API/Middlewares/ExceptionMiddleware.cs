
using System.Net;
using System.Text.Json;

namespace eShelf.API.Middlewares
{
    public class ExceptionMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch(Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        public static Task HandleExceptionAsync(HttpContext currentContex, Exception excp)
        {
            var exceptionResponse = new
            {
                Status = HttpStatusCode.InternalServerError,
                Info = "ERROR",
                Message = excp.Message,
                StTrace = excp.StackTrace
            };

            currentContex.Response.ContentType = "application/json";
            currentContex.Response.StatusCode = 500;

            string response = JsonSerializer.Serialize(exceptionResponse);

            return currentContex.Response.WriteAsync(response);
        }
    }
}
