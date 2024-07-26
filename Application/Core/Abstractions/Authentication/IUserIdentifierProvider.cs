namespace Application.Core.Abstractions.Authentication;

public interface IUserIdentifierProvider
{
    Guid UserId { get; }
}
