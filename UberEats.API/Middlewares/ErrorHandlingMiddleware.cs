using UberEats.API.Errors;
using UberEats.Domain.Exceptions;

namespace UberEats.API.Middlewares
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
       private readonly ILogger<ErrorHandlingMiddleware> _logger;
        public ErrorHandlingMiddleware( ILogger<ErrorHandlingMiddleware> logger)
        {

            _logger = logger;

        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch(NotFoundException notFound)
            {
                _logger.LogInformation(notFound.Message);
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                await context.Response.WriteAsJsonAsync(new NotFoundError(notFound.Message));
            }
            catch (ConflictException conf)
            {
                _logger.LogInformation(conf.Message);
                context.Response.StatusCode = StatusCodes.Status409Conflict;
                await context.Response.WriteAsJsonAsync(new ConflictError(conf.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,ex.Message);
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                var errorResponse = new { error = "Something went wrong" };

                await  context.Response.WriteAsJsonAsync(errorResponse);
            }
        }
    }
}
