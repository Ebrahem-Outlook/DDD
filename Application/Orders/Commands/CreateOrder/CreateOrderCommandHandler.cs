using Application.Core.Abstractions.Data;
using Application.Core.Abstractions.Messaging;
using Domain.Orders;

namespace Application.Orders.Commands.CreateOrder;

internal sealed class CreateOrderCommandHandler : ICommandHandler<CreateOrderCommand, OrderDTO>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateOrderCommandHandler(IOrderRepository orderRepository, IUnitOfWork unitOfWork)
    {
        _orderRepository = orderRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<OrderDTO> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        Order order = Order.Create(request.UserId, request.Products);

        await _orderRepository.AddAsync(order, cancellationToken);

        OrderDTO orderDTO = new OrderDTO(order.Id, order.TotalPrice, order.Products, order.CreatedAt);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return orderDTO;
    }
}
