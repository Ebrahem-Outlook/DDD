using Application.Core.Abstractions.Messaging;
using Application.Orders.Commands.CreateOrder;

namespace Application.Orders.Queries.GetOrderById;

public sealed record GetOrderByIdQuery(Guid OrderId) : IQuery<OrderDTO>;
