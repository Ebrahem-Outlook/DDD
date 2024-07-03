namespace Application.Products.Commands.CreateProduct;

public sealed record ProductDTO(
    Guid ProductId,
    Guid UserId, 
    string Name,
    string Description,
    decimal Price,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
