using Newtonsoft.Json;
using System.Net;
using static BooksService.Domain.Exceptions.CategoryExceptions;
using static BooksService.Domain.Exceptions.UserExceptions;

namespace BooksService.Api.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(
            RequestDelegate next,
            ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception handled with ErrorMessage: {Message}, Path {Path}", ex.Message, context.Request.Path);
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
                CategoryNotFoundException => (int)HttpStatusCode.BadRequest,
                InvalidOperationException => (int)HttpStatusCode.BadRequest,
                _ => (int)HttpStatusCode.InternalServerError,
            };

            var result = JsonConvert.SerializeObject(new { error = ex.Message });
            response.StatusCode = statusCode;

            return response.WriteAsync(result);
        }
    }
}
