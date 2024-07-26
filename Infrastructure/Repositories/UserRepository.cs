using Application.Core.Abstractions.Data;
using Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

internal sealed class UserRepository(IDbContext dbContext) : IUserRepository
{
    public async Task AddAsync(User user, CancellationToken cancellationToken = default)
    {
        await dbContext.Set<User>().AddAsync(user, cancellationToken);
    }

    public void Update(User user)
    {
        dbContext.Set<User>().Update(user);
    }

    public void Delete(User user)
    {
        dbContext.Set<User>().Remove(user);
    }

    public async Task<List<User>?> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await dbContext.Set<User>().ToListAsync(cancellationToken);
    }

    public async Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await dbContext.Set<User>().FirstOrDefaultAsync(user => user.Id == id, cancellationToken);
    }
}
