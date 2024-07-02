using Application.Core.Abstractions.Data;
using Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

internal sealed class UserRepository : IUserRepository
{
    private readonly IDbContext _dbContext;

    public UserRepository(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(User user, CancellationToken cancellationToken = default)
    {
        await _dbContext.Set<User>().AddAsync(user, cancellationToken);
    }

    public void Update(User user)
    {
        _dbContext.Set<User>().Update(user);
    }

    public void Delete(User user)
    {
        _dbContext.Set<User>().Remove(user);
    }

    public async Task<List<User>?> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<User>().ToListAsync(cancellationToken);
    }

    public async Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<User>().FirstOrDefaultAsync(user => user.Id == id, cancellationToken);
    }

    public async Task<bool> IsEmailUnique(string email, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<User>().AnyAsync(user => user.Email == email, cancellationToken);
    }
}
