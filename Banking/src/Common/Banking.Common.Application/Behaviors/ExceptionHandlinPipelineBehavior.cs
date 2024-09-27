using Banking.Common.Application.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Banking.Common.Application.Behaviors;
internal sealed class ExceptionHandlinPipelineBehavior<TRequest, TResponse>(
    ILogger<ExceptionHandlinPipelineBehavior<TRequest, TResponse>> logger)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class
{
    public async Task<TResponse> Handle(
        TRequest request, 
        RequestHandlerDelegate<TResponse> next, 
        CancellationToken cancellationToken)
    {
        try
        {
            return await next();
        }
        catch (Exception exception)
        {
            logger.LogError(exception, "Unhandled exception for {RequestName}", typeof(TRequest).Name);

            throw new BankingException(typeof(TRequest).Name, innerException: exception);
        }
    }
}
