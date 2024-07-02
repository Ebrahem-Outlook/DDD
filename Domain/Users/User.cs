using Domain.Core.Premitives;
using Domain.Users.Events;

namespace Domain.Users;

public sealed class User : AggregateRoot
{
    private User(Guid id, string firstName, string lastName, string email, string password) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
    }

    private User() : base() { }

    public string FirstName { get; private set; } = default!;
    public string LastName { get; private set; } = default!;
    public string Email { get; private set; } = default!;
    public string Password { get; private set; } = default!;

    public static User Create(string firstName, string lastName, string email, string password)
    {
        User user = new(Guid.NewGuid(), firstName, lastName, email, password);

        user.AddDomainEvent(new UserCreatedDomainEvent(user.Id, user.FirstName, user.LastName, user.Email, user.Password));

        return user;
    }

    public void ChangeName(string firstName, string lastName)
    {
        FirstName = firstName ?? string.Empty;
        LastName = lastName ?? string.Empty;

        AddDomainEvent(new UserNameChangedDomainEvent(Id, FirstName, LastName));
    }

    public void ChangeEmail(string email)
    {
        Email = email ?? throw new ArgumentNullException();

        AddDomainEvent(new UserEmailChangedDomainEvent(Id, Email));
    }

    public void ChangePassword(string password)
    {
        Password = password ?? throw new ArgumentNullException();

        AddDomainEvent(new UserPasswordChangedDomainEvent(Id, Password));
    }
}
