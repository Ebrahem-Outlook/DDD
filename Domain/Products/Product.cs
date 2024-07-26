using Domain.Core.BaseType;
using Domain.Products.Events;

namespace Domain.Products;

public sealed class Product : AggregateRoot
{
    public const int MaxLength_Name = 30;
    public const int MaxLength_Description = 500;
    
    /// <summary>
    /// Initialize a new instance of the <see cref="Product"/> class.
    /// </summary>
    /// <param name="productId">The identifier of product.</param>
    /// <param name="userId">The identifier of user Created this product.</param>
    /// <param name="name">The name of product.</param>
    /// <param name="description">The description of product.</param>
    /// <param name="price">The price of product.</param>
    private Product(Guid userId, Guid productId, string name, string description, decimal price) : base(productId)
    {
        UserId = userId;
        Name = name;
        Description = description;
        Price = price;
        CreatedAt = DateTime.UtcNow;
    }

    /// <summary>
    /// Required By EFCore.
    /// </summary>
    private Product() : base() { }

    /// <summary>
    /// Foreignkey for User (owner).
    /// </summary>
    public Guid UserId { get; }

    /// <summary>
    /// Gets the name of this product.
    /// </summary>
    public string Name { get; private set; } = default!;

    /// <summary>
    /// Gets the description of this product.
    /// </summary>
    public string Description { get; private set; } = default!;

    /// <summary>
    /// Gets the price of this product.
    /// </summary>
    public decimal Price { get; private set; }

    /// <summary>
    /// Gete the dateTime Created of this product.
    /// </summary>
    public DateTime CreatedAt { get; }

    /// <summary>
    /// Gets the last date time updated of this product.
    /// </summary>
    public DateTime? UpdatedAt { get; private set; }


    /// <summary>
    /// Factory Method to controlle the creation of instance and apply the required validation.
    /// </summary>
    /// <param name="userId">The identifier the user create this product.</param>
    /// <param name="name">The name of product.</param>
    /// <param name="description">The description of product.</param>
    /// <param name="price">The price of product.</param>
    /// <returns></returns>
    /// <exception cref="ArgumentException">The Exception throw when any parameter doesn't have the required validation.</exception>
    public static Product Create(Guid userId, string name, string description, decimal price)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(name) || name.Length > MaxLength_Name)
            {
                throw new ArgumentException("Name maybe null Or Longer than the Max Length");
            }

            if (string.IsNullOrWhiteSpace(description) || description.Length > MaxLength_Description)
            {
                throw new ArgumentException("Name maybe null Or Longer than the Max Length");
            }

            if (price <= 0)
            {
                throw new ArgumentException("Price is rquired ...Please..");
            }

            Product product = new Product(userId, Guid.NewGuid(), name, description, price);

            product.RaiseDomainEvent(new ProductCreatedDomainEvent(product.Id, product.Name, product.Description, product.Price, product.CreatedAt));

            return product;
        }
        catch(ArgumentException)
        {
            throw;
        }
    }

    /// <summary>
    /// The Updated Method to Update the content of the product. with required validation.
    /// </summary>
    /// <param name="userId">The user identifier created this product.</param>
    /// <param name="name">The name of this product.</param>
    /// <param name="description">The description of this product.</param>
    /// <param name="price">The price of this product.</param>
    /// <exception cref="ArgumentException">The Exception throw when any paramert doesn't have the required validation.</exception>
    public void Update(Guid userId, string name, string description, decimal price)
    {
        try
        {
            if (UserId != userId)
            {
                throw new ArgumentException($"UsreId ({userId}) does not match.");
            }

            if (string.IsNullOrWhiteSpace(name) || name.Length > MaxLength_Name)
            {
                throw new ArgumentException("Name maybe null Or Longer than the Max Length");
            }

            if (string.IsNullOrWhiteSpace(description) || description.Length > MaxLength_Description)
            {
                throw new ArgumentException("Name maybe null Or Longer than the Max Length");
            }

            if (price <= 0)
            {
                throw new ArgumentException("Price is rquired ...Please..");
            }

            Name = name;
            Description = description;
            Price = price;
            UpdatedAt = DateTime.UtcNow;

            RaiseDomainEvent(new ProductUpdatedDomainEvent(Id, Name, Description, Price, CreatedAt, UpdatedAt));
        }
        catch(ArgumentException)
        {
            return;
        }
    }
}
