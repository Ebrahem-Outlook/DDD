namespace API.Contracts.Product;

public sealed record CreateProductRequest(
    Guid UserId,
    string Name, 
    string Description, 
    decimal Price);
