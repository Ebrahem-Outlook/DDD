using Application.Core.Abstractions.Messaging;
using Domain.Products;

namespace Application.Products.Queries.GetAllProduct;

public sealed record GetAllProductsQuery() : IQuery<List<Product>>;
