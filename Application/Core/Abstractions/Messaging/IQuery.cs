using MediatR;

namespace Application.Core.Abstractions.Messaging;

public interface IQuery : IRequest
{

}

public interface IQuery<TResponse> : IRequest<TResponse>
{

}
