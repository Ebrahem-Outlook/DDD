using Domain.Users;

namespace Application.Core.Abstractions.Authentication;

/// <summary>
/// Representes the JWT provider interface.
/// </summary>
public interface IJwtProvider
{
    /// <summary>
    /// Generate the JWT for the specified user.
    /// </summary>
    /// <param name="user">The user.</param>
    /// <returns>The JWT for the specified user.</returns>
    string GenerateToken(User user);
}
