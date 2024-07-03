using Application.Core.Abstractions.Data;
using Application.Core.Abstractions.Messaging;
using Domain.Products;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Users.Queries.GetAllProducts;

internal sealed class GetAllProductsOfUserQueryHandler : IQueryHandler<GetAllProductsOfUserQuery, List<Product>>
{
    private readonly IDbContext _dbContext;

    public GetAllProductsOfUserQueryHandler(IDbContext dbContext) => _dbContext = dbContext;
    
    public async Task<List<Product>> Handle(GetAllProductsOfUserQuery request, CancellationToken cancellationToken)
    {
        return await _dbContext.Set<Product>().Where(p => p.UserId == request.UserId).ToListAsync(cancellationToken);
    }
}
