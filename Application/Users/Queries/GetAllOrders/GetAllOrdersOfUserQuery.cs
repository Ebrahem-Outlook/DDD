using Application.Core.Abstractions.Messaging;
using Domain.Orders;

namespace Application.Users.Queries.GetAllOrders;

public sealed record GetAllOrdersOfUserQuery(Guid UserId) : IQuery<List<Order>>;
