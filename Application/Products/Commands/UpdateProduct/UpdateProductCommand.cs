using Application.Core.Abstractions.Messaging;
using Application.Products.Commands.CreateProduct;

namespace Application.Products.Commands.UpdateProduct;

public sealed record UpdateProductCommand(
    Guid ProductId, 
    Guid UserId,
    string Name,
    string Description, 
    decimal Price) : ICommand<ProductDTO>;
