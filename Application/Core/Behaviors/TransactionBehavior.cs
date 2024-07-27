using Application.Core.Abstractions.Data;
using Application.Core.Abstractions.Messaging;
using MediatR;
using Microsoft.EntityFrameworkCore.Storage;

namespace Application.Core.Behaviors;

internal sealed class TransactionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest
    where TResponse : class
{
    private readonly IUnitOfWork _unitOfWork;

    public TransactionBehavior(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (request is IQuery<TResponse>)
        {
            return await next();
        }

        await using IDbContextTransaction transaction = await _unitOfWork.BeginTransaction(cancellationToken);

        try
        {
            TResponse response = await next();

            await transaction.CommitAsync(cancellationToken);

            return response;
        }
        catch(Exception)
        {
            await transaction.RollbackAsync(cancellationToken);

            throw;
        }
    }
}
