using Odyssey.Domain.Users;

namespace Odyssey.Application.Common.Auth;

public interface ITokenService
{
    string CreateAccessToken(User user);
    string CreateRefreshToken();
}
