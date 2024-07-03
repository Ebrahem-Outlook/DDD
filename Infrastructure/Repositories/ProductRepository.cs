using Application.Core.Abstractions.Data;
using Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

internal sealed class ProductRepository : IProductRepository
{
    private readonly IDbContext _dbContext;

    public ProductRepository(IDbContext dbContext) => _dbContext = dbContext;

    public async Task AddAsync(Product product, CancellationToken cancellationToken = default)
    {
        await _dbContext.Set<Product>().AddAsync(product, cancellationToken);
    }

    public void Update(Product product)
    {
        _dbContext.Set<Product>().Update(product);
    }

    public void Delete(Product product)
    {
        _dbContext.Set<Product>().Remove(product);
    }

    public async Task<List<Product>?> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<Product>().ToListAsync(cancellationToken);
    }

    public async Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<Product>().FirstOrDefaultAsync(user => user.Id == id, cancellationToken);
    }
}
