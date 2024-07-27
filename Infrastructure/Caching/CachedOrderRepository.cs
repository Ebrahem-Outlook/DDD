using Domain.Orders;
using Infrastructure.Repositories;
using Microsoft.Extensions.Caching.Memory;

namespace Infrastructure.Caching;

internal sealed class CachedOrderRepository(OrderRepository decorated, IMemoryCache memoryCache) : IOrderRepository
{
    public async Task AddAsync(Order order, CancellationToken cancellationToken = default)
    {
        await decorated.AddAsync(order, cancellationToken);
        string key = $"Key-{order.Id}";
        memoryCache.Remove(key);
    }

    public void Delete(Order order)
    {
        decorated.Delete(order);
        string key = $"Key-{order.Id}";
        memoryCache.Remove(key);
    }

    public async Task<List<Order>?> GetAllAsync(CancellationToken cancellationToken = default)
    {
        string key = "Key-Orders";
        return await memoryCache.GetOrCreateAsync(key, Entry =>
        {
            Entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(5));

            return decorated.GetAllAsync(cancellationToken);
        });
    }

    public async Task<Order?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        string key = "Key-{id}";
        return await memoryCache.GetOrCreateAsync(key, Entry =>
        {
            Entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(5));

            return decorated.GetByIdAsync(id, cancellationToken);
        });
    }
}
