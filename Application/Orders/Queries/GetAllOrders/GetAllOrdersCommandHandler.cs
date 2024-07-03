using Application.Core.Abstractions.Data;
using Application.Core.Abstractions.Messaging;
using Domain.Orders;

namespace Application.Orders.Queries.GetAllOrders;

internal sealed class GetAllOrdersCommandHandler : ICommandHandler<GetAllOrdersCommand, List<Order>>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GetAllOrdersCommandHandler(IOrderRepository orderRepository, IUnitOfWork unitOfWork)
    {
        _orderRepository = orderRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<List<Order>> Handle(GetAllOrdersCommand request, CancellationToken cancellationToken)
    {
        return await _orderRepository.GetAllAsync(cancellationToken) ?? throw new NullReferenceException();
    }
}
