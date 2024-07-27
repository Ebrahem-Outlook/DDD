using Domain.Users;
using Infrastructure.Repositories;
using Microsoft.Extensions.Caching.Memory;

namespace Infrastructure.Caching;

internal sealed class CachedUserRepository(UserRepository decorated, IMemoryCache memoryCache) : IUserRepository
{
    public async Task AddAsync(User user, CancellationToken cancellationToken = default)
    {
        await decorated.AddAsync(user, cancellationToken);
        string key = $"Key-{user.Id}";
        memoryCache.Remove(key);
    }

    public void Update(User user)
    {
        decorated.Update(user);
        string key = $"Key-{user.Id}";
        memoryCache.Remove(key);
    }

    public void Delete(User user)
    {
        decorated.Delete(user);
        string key = $"Key-{user.Id}";
        memoryCache.Remove(key);
    }

    public async Task<List<User>?> GetAllAsync(CancellationToken cancellationToken = default)
    {
        string key = $"Key-Users";
        return await memoryCache.GetOrCreateAsync(key, Entry =>
        {
            Entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(5));

            return decorated.GetAllAsync();
        });
    }

    public async Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        string key = $"Key-{id}";
        return await memoryCache.GetOrCreateAsync(key, Entry =>
        {
            Entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(5));

            return decorated.GetByIdAsync(id, cancellationToken);
        });
    }
}
