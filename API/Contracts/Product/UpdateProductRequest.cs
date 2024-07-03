namespace API.Contracts.Product;

public sealed record UpdateProductRequest(Guid ProductId, Guid UserId, string Name, string Description, decimal Price);
