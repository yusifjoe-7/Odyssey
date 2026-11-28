using MediatR;
using Odyssey.Application.Common.Auth;
using Odyssey.Application.Common.Persistence.Interfaces;
using Odyssey.Domain.Common.Security;
using Odyssey.Domain.Users;

namespace Odyssey.Application.Users.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResult>
{
    private const int RefreshTokenExpirationDays = 7;

    private readonly IUserDb _userDb;
    private readonly IRefreshTokenDb _refreshTokenDb;
    private readonly ITokenService _tokenService;

    public LoginCommandHandler(IUserDb userDb, IRefreshTokenDb refreshTokenDb, ITokenService tokenService)
    {
        _userDb = userDb;
        _refreshTokenDb = refreshTokenDb;
        _tokenService = tokenService;
    }

    public async Task<LoginResult> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.UserName))
            throw new ArgumentException("UserName canot be empty", nameof(request.UserName));
        if (string.IsNullOrWhiteSpace(request.Password))
            throw new ArgumentException("Password canot be empty", nameof(request.Password));

        var user = await _userDb.FindUserByUserNameAsync(request.UserName, cancellationToken);

        // Same error whether the user is missing or the password is wrong (don't leak which).
        if (user is null || !PasswordHasher.Verify(request.Password, user.HashedPassword))
            throw new UnauthorizedAccessException("Invalid username or password");

        var accessToken = _tokenService.CreateAccessToken(user);

        var refreshToken = new RefreshToken
        {
            Token = _tokenService.CreateRefreshToken(),
            UserId = user.Id,
            CreatedAt = DateTime.UtcNow,
            ExpiresAt = DateTime.UtcNow.AddDays(RefreshTokenExpirationDays),
            RevokedAt = null
        };

        _refreshTokenDb.RefreshTokens.Add(refreshToken);
        await _refreshTokenDb.SaveChangesAsync(cancellationToken);

        return new LoginResult(accessToken, refreshToken.Token);
    }
}
