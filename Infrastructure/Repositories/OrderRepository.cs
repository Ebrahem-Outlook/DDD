using Application.Core.Abstractions.Data;
using Domain.Orders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

internal sealed class OrderRepository : IOrderRepository
{
    private readonly IDbContext _dbContext;

    public OrderRepository(IDbContext dbContext) => _dbContext = dbContext;
    
    public async Task AddAsync(Order order, CancellationToken cancellationToken = default)
    {
        await _dbContext.Set<Order>().AddAsync(order, cancellationToken);
    }

    public void Delete(Order order)
    {
        _dbContext.Set<Order>().Remove(order);
    }

    public async Task<List<Order>?> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<Order>().ToListAsync(cancellationToken);
    }

    public async Task<Order?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<Order>().FirstOrDefaultAsync(user => user.Id == id, cancellationToken);
    }
}
