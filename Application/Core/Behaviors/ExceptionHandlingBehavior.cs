using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Core.Behaviors;

internal sealed class ExceptionHandlingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest
    where TResponse : class
{
    private readonly ILogger<ExceptionHandlingBehavior<TRequest, TResponse>> _logger;

    public ExceptionHandlingBehavior(ILogger<ExceptionHandlingBehavior<TRequest, TResponse>> logger) => _logger = logger;

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        try
        {
            return await next();
        }
        catch(Exception)
        {
            _logger.LogError("Request Failure {@RequestName}, {@RequestDate}", typeof(TRequest).Name, DateTime.UtcNow);

            throw;
        }
    }
}
