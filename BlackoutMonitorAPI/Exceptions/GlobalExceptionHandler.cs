using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BlackoutMonitorAPI.Exceptions
{
    public class GlobalExceptionHandler : IExceptionFilter
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            ObjectResult result;

            switch (exception)
            {
                case RegionNotFoundException:
                    result = new NotFoundObjectResult(new { error = exception.Message });
                    break;

                case UserNotAuthenticatedException:
                    result = new UnauthorizedObjectResult(new { error = exception.Message });
                    break;

                case AlertCreationException:
                    result = new ObjectResult(new { error = exception.Message })
                    {
                        StatusCode = 500
                    };
                    break;

                case DatabaseUnavailableException:
                    result = new ObjectResult(new { error = "Banco de dados indisponível." })
                    {
                        StatusCode = 503
                    };
                    break;  

                default:
                    _logger.LogError(exception, "Erro não tratado.");
                    result = new ObjectResult(new { error = "Erro interno no servidor." })
                    {
                        StatusCode = 500
                    };
                    break;
            }

            context.Result = result;
            context.ExceptionHandled = true;
        }
    }
}
