using Application.Core.Abstractions.Data;
using Application.Core.Abstractions.Messaging;
using Application.Orders.Commands.CreateOrder;
using Domain.Orders;

namespace Application.Orders.Commands.DeleteOrder;

internal sealed class DeleteOrderCommandHandler : ICommandHandler<DeleteOrderCommand, OrderDTO>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteOrderCommandHandler(IOrderRepository orderRepository, IUnitOfWork unitOfWork)
    {
        _orderRepository = orderRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<OrderDTO> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        Order order = await _orderRepository.GetByIdAsync(request.OrderId, cancellationToken)
            ?? throw new NullReferenceException();

        _orderRepository.Delete(order);

        OrderDTO orderDTO = new OrderDTO(order.Id, order.TotalPrice, order.Products, order.CreatedAt);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return orderDTO;
    }
}
