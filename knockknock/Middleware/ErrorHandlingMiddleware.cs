using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace KnockKnock.Api.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context /* other scoped dependencies */)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.BadRequest; // 500 if unexpected
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            if (exception is ArgumentOutOfRangeException)
            {
                code = HttpStatusCode.NoContent;
                return context.Response.WriteAsync(string.Empty);
            }

            var result = JsonConvert.SerializeObject(new { message = "The request is invalid." });

            return context.Response.WriteAsync(result);
        }
    }
}