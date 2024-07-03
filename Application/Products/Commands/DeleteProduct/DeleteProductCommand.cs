using Application.Core.Abstractions.Messaging;
using Application.Products.Commands.CreateProduct;

namespace Application.Products.Commands.DeleteProduct;

public sealed record DeleteProductCommand(Guid ProductId) : ICommand<ProductDTO>;
