using Domain.Core.Premitives;
using Domain.Orders.Events;
using Domain.Products;

namespace Domain.Orders;

public sealed class Order : AggregateRoot
{
    /// <summary>
    /// Create a new instance of <see cref="Order"/> class.
    /// </summary>
    /// <param name="UserId">The identifier of user he create this order.</param>
    /// <param name="orderId">The identifier of order.</param>
    /// <param name="products">The list of products for this order.</param>
    private Order(Guid UserId, Guid orderId, ICollection<Product> products) : base(orderId)
    {
        _products = products.ToList();
        TotalPrice = products.Sum(p => p.Price);
        CreatedAt = DateTime.UtcNow;
    }

    /// <summary>
    /// EFCore Required.
    /// </summary>
    private Order() { }

    /// <summary>
    /// Gets The identifier of user that create this order.
    /// </summary>
    public Guid UserId { get; }

    /// <summary>
    /// The total price of the product in this order.
    /// </summary>
    public decimal TotalPrice { get; private set; }

    /// <summary>
    /// The Date time of Created.
    /// </summary>
    public DateTime CreatedAt { get; private set; }

    /// <summary>
    /// The List of products.
    /// </summary>
    private List<Product> _products = new List<Product>();
    public ICollection<Product> Products => _products.AsReadOnly();

    /// <summary>
    /// Factory Method to controlle the craetion of order.
    /// </summary>
    /// <param name="userId">The identifier of user.</param>
    /// <param name="products">The list of product in side the order.</param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">The Exception throw when any parameter doesn't have the required validation.</exception>
    public static Order Create(Guid userId, ICollection<Product> products)
    {
        if (products is null)
        {
            throw new ArgumentNullException("Products Required ... To Create Order you should Create alist of Product.");
        }

        if (userId == Guid.Empty)
        {
            throw new ArgumentNullException("UserId is required.");
        }

        Order order = new Order(userId, Guid.NewGuid(), products);

        order.AddDomainEvent(new OrderCreatedDomainEvent(order.UserId, order.Id, order.TotalPrice, order.CreatedAt));

        return order;
    }
}
