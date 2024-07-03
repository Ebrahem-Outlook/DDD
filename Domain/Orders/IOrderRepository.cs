namespace Domain.Orders;

public interface IOrderRepository
{

    // Commands.
    Task AddAsync(Order order, CancellationToken cancellationToken = default);
    void Delete(Order order);

    // Queries.
    Task<List<Order>?> GetAllAsync(CancellationToken cancellationToken = default);
    Task GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
}



