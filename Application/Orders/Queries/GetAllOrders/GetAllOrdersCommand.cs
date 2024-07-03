using Application.Core.Abstractions.Messaging;
using Domain.Orders;
using Domain.Users;

namespace Application.Orders.Queries.GetAllOrders;

public sealed record GetAllOrdersCommand(Guid OrderId) : ICommand<List<Order>>;
