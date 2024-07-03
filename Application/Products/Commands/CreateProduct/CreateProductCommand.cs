using Application.Core.Abstractions.Messaging;

namespace Application.Products.Commands.CreateProduct;

public sealed record CreateProductCommand(
    Guid UserId,
    string Name, 
    string Description, 
    decimal Price) : ICommand<ProductDTO>;
