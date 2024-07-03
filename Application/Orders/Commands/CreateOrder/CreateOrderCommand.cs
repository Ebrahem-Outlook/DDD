using Application.Core.Abstractions.Messaging;
using Domain.Products;

namespace Application.Orders.Commands.CreateOrder;

public sealed record CreateOrderCommand(Guid UserId, ICollection<Product> Products) : ICommand<OrderDTO>;
