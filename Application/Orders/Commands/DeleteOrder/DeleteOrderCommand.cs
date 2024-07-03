using Application.Core.Abstractions.Messaging;
using Application.Orders.Commands.CreateOrder;

namespace Application.Orders.Commands.DeleteOrder;

public sealed record DeleteOrderCommand(Guid OrderId) : ICommand<OrderDTO>;
