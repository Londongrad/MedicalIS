using MedicalIS.Application.Exceptions;

namespace MedicalIS.WebApi.Middleware
{
    public class ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        private readonly RequestDelegate _next = next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger = logger;

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning(ex, "Validation error");

                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsJsonAsync(new
                {
                    error = ex.Message
                });
            }
            catch (NotFoundException ex)
            {
                _logger.LogWarning(ex, "Not found error");

                context.Response.StatusCode = StatusCodes.Status404NotFound;
                await context.Response.WriteAsJsonAsync(new
                {
                    error = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error");

                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsJsonAsync(new
                {
                    error = "Internal Server Error"
                });
            }
        }
    }
}
