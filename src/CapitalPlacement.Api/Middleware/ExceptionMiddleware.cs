using CapitalPlacement.Api.Models;
using CapitalPlacement.Core.Exceptions;

namespace CapitalPlacement.Api.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _request;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate request, ILogger<ExceptionMiddleware> logger)
        {
            _request = request;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _request(context);
            }
            catch (NotFoundException ex)
            {
                _logger.LogInformation("A NotFound Exception has occurred while executing the request: {ErrorMessage}", ex.Message);

                await Results.NotFound(new ResponseModel
                {
                    HasError = true,
                    Message = ex.Message

                }).ExecuteAsync(context);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unhandled exception has occurred while executing the request {ErrorMessage}", ex.Message);

                await Results.NotFound(new ResponseModel
                {
                    HasError = true,
                    Message = ex.Message

                }).ExecuteAsync(context);

            }
        }
    }
}
