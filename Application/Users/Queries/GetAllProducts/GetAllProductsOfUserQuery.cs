using Application.Core.Abstractions.Messaging;
using Domain.Products;

namespace Application.Users.Queries.GetAllProducts;

public sealed record GetAllProductsOfUserQuery(Guid UserId) : IQuery<List<Product>>;
