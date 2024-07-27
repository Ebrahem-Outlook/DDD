using Application.Core.Abstractions.Authentication;
using Domain.Users;
using Microsoft.Extensions.Options;

namespace Infrastructure.Authentication;

internal sealed class JwtProvider(IOptions<>) : IJwtProvider
{
    public string GenerateToken(User user)
    {
        throw new NotImplementedException();
    }
}
