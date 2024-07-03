using Application.Core.Abstractions.Messaging;
using Application.Orders.Commands.CreateOrder;
using Domain.Orders;

namespace Application.Orders.Queries.GetOrderById;

internal sealed class GetOrderByIdQueryHandler : IQueryHandler<GetOrderByIdQuery, OrderDTO>
{
    private readonly IOrderRepository _orderRepository;

    public GetOrderByIdQueryHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<OrderDTO> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        Order order = await _orderRepository.GetByIdAsync(request.OrderId) ?? throw new NullReferenceException();

        return new OrderDTO(order.Id, order.TotalPrice, order.Products, order.CreatedAt);
    }
}
