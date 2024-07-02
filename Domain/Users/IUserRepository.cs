namespace Domain.Users;

public interface IUserRepository
{
    // Commands.
    Task AddAsync(User user, CancellationToken cancellationToken = default);
    void Update(User user);
    void Delete(User user);
    
    // Queries.
    Task<List<User>?> GetAllAsync(CancellationToken cancellationToken = default);
    Task<User> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<bool> IsEmailUnique(string email, CancellationToken cancellationToken = default);
}
