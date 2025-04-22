using Newtonsoft.Json;
using System.Net;
using static BooksService.Domain.Exceptions.UserExceptions;

namespace BooksService.Api.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
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

        private static Task HandleExceptionAsync(HttpContext context, Exception ex) 
        {
            var response = context.Response;
            response.ContentType = "application/json";

            var statusCode = ex switch
            {
                BadHttpRequestException => (int)HttpStatusCode.BadRequest,
                DuplicateUserException => (int)HttpStatusCode.BadRequest,
                UserNotFoundException => (int)HttpStatusCode.BadRequest,
                _ => (int)HttpStatusCode.InternalServerError,
            };

            var result = JsonConvert.SerializeObject(new { error = ex.Message });
            response.StatusCode = statusCode;

            return response.WriteAsync(result);
        }
    }
}
