using Domain.Core.BaseType;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Application.Core.Abstractions.Data;

public interface IDbContext
{
    DbSet<TEntity> Set<TEntity>() where TEntity : Entity;
}

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    Task<IDbContextTransaction> BeginTransaction(CancellationToken cancellationToken);
}

