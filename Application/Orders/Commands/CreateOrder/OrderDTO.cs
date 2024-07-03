using Domain.Products;

namespace Application.Orders.Commands.CreateOrder;

public sealed record OrderDTO(
    Guid OrderId,
    decimal TotalPrice,
    ICollection<Product> Products,
    DateTime CreatedAt);
