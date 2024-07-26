using Application.Core.Abstractions.Data;
using Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

internal sealed class ProductRepository(IDbContext dbContext) : IProductRepository
{
    public async Task AddAsync(Product product, CancellationToken cancellationToken = default)
    {
        await dbContext.Set<Product>().AddAsync(product, cancellationToken);
    }

    public void Update(Product product)
    {
        dbContext.Set<Product>().Update(product);
    }

    public void Delete(Product product)
    {
        dbContext.Set<Product>().Remove(product);
    }

    public async Task<List<Product>?> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await dbContext.Set<Product>().ToListAsync(cancellationToken);
    }

    public async Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await dbContext.Set<Product>().FirstOrDefaultAsync(user => user.Id == id, cancellationToken);
    }
}
