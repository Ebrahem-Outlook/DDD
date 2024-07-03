using Domain.Core.Premitives;
using Domain.Orders;
using Domain.Products;
using Domain.Users.Events;

namespace Domain.Users;

public sealed class User : AggregateRoot
{
    private const int MaxLength_FirstName = 30;
    private const int MaxLength_LastName = 30;
    private const int MaxLength_Email = 30;
    private const int MaxLength_Password = 30;

    /// <summary>
    /// Initialize a new instance of the <see cref="User"/> calss.
    /// </summary>
    /// <param name="id">The identifier of new user.</param>
    /// <param name="firstName">The first name of user.</param>
    /// <param name="lastName">The last name of user.</param>
    /// <param name="email">The email of user.</param>
    /// <param name="password">The password of user.</param>
    private User(Guid id, string firstName, string lastName, string email, string password) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
    }

    /// <summary>
    /// Required by EFCore.
    /// </summary>
    private User() : base() { }

    /// <summary>
    /// Gets and sets the first name of user.
    /// </summary>
    public string FirstName { get; private set; } = default!;

    /// <summary>
    /// Gets and sets the last name of user.
    /// </summary>
    public string LastName { get; private set; } = default!;

    /// <summary>
    /// Gets and sets the email of user.
    /// </summary>
    public string Email { get; private set; } = default!;

    /// <summary>
    /// Gets and sets the password of user.
    /// </summary>
    public string Password { get; private set; } = default!;

    /// <summary>
    /// The list of Order that user created.
    /// </summary>
    private readonly List<Order> _orders = new List<Order>();
    public IReadOnlyCollection<Order> Orders => _orders.AsReadOnly();

    /// <summary>
    /// The of Product that user created.
    /// </summary>
    private readonly List<Product> _products = new List<Product>();
    public IReadOnlyCollection<Product> Products => _products.AsReadOnly();


    /// <summary>
    /// Factory method to controlle the creation of user with spicified validation.
    /// </summary>
    /// <param name="firstName">The first name of user.</param>
    /// <param name="lastName">The last name of user.</param>
    /// <param name="email">The email of user.</param>
    /// <param name="password">The password of user.</param>
    /// <returns></returns>
    public static User Create(string firstName, string lastName, string email, string password)
    {
        if (string.IsNullOrEmpty(firstName) || firstName.Length > MaxLength_Email) 
        {
            throw new ArgumentException("First Name maybe null or longer than the Max Length.");
        }

        if (string.IsNullOrWhiteSpace(lastName) || lastName.Length > MaxLength_LastName)
        {
            throw new ArgumentException("Last Name maybe null or longer than the Max Length.");
        }

        if (string.IsNullOrWhiteSpace(email) || email.Length > MaxLength_Email)
        {
            throw new ArgumentException("Email maybe null or longer than the Max Length.");
        }

        if (string.IsNullOrWhiteSpace(password) || password.Length > MaxLength_Password)
        {
            throw new ArgumentException("Password maybe null or longer than the Max Length.");
        }

        User user = new(Guid.NewGuid(), firstName, lastName, email, password);

        user.AddDomainEvent(new UserCreatedDomainEvent(user.Id, user.FirstName, user.LastName, user.Email, user.Password));

        return user;
    }


    /// <summary>
    /// Method to update the name of user to new name.
    /// </summary>
    /// <param name="firstName">The new first name of user.</param>
    /// <param name="lastName">The new last name of user.</param>
    /// <exception cref="ArgumentException">The Exception throw when any parameter doesn't have the required validation.</exception>
    public void ChangeName(string firstName, string lastName)
    {
        if (string.IsNullOrEmpty(firstName) || firstName.Length > MaxLength_Email)
        {
            throw new ArgumentException("First Name maybe null or longer than the Max Length.");
        }

        if (string.IsNullOrWhiteSpace(lastName) || lastName.Length > MaxLength_LastName)
        {
            throw new ArgumentException("Last Name maybe null or longer than the Max Length.");
        }

        FirstName = firstName;
        LastName = lastName;

        AddDomainEvent(new UserNameChangedDomainEvent(Id, FirstName, LastName));
    }

    /// <summary>
    /// Method to update the email of user to new email.
    /// </summary>
    /// <param name="email">The new email of user.</param>
    /// <exception cref="ArgumentException">The Exception throw when any parameter doesn't have the required validation.</exception>
    public void ChangeEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email) || email.Length > MaxLength_Email)
        {
            throw new ArgumentException("Email maybe null or longer than the Max Length.");
        }

        Email = email;

        AddDomainEvent(new UserEmailChangedDomainEvent(Id, Email));
    }

    /// <summary>
    /// Methoed to update the password of user to new password.
    /// </summary>
    /// <param name="password">The new password of user.</param>
    /// <exception cref="ArgumentException">The Exception throw when any parameter doesn't have the required validation.</exception>
    public void ChangePassword(string password)
    {
        if (string.IsNullOrWhiteSpace(password) || password.Length > MaxLength_Password)
        {
            throw new ArgumentException("Password maybe null or longer than the Max Length.");
        }

        Password = password;

        AddDomainEvent(new UserPasswordChangedDomainEvent(Id, Password));
    }

    /// <summary>
    /// Method to add a new order to the list of user orders.
    /// </summary>
    /// <param name="order"></param>
    public void AddOrder(Order order)
    {
        _orders.Add(order);
    }

    /// <summary>
    /// Method to add a new product to the list of user product.
    /// </summary>
    /// <param name="product"></param>
    public void AddProduct(Product product)
    {
        _products.Add(product);
    }
}
