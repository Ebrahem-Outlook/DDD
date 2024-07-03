using Application.Core.Abstractions.Messaging;
using Application.Products.Commands.CreateProduct;

namespace Application.Products.Queries.GetProductById;

public sealed record GetProductByIdQuery(Guid ProductId) : IQuery<ProductDTO>;
