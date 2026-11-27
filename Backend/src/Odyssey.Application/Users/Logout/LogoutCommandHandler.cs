using MediatR;
using Microsoft.EntityFrameworkCore;
using Odyssey.Application.Common.Persistence.Interfaces;

namespace Odyssey.Application.Users.Logout;

public class LogoutCommandHandler : IRequestHandler<LogoutCommand>
{
    private readonly IRefreshTokenDb _refreshTokenDb;

    public LogoutCommandHandler(IRefreshTokenDb refreshTokenDb)
    {
        _refreshTokenDb = refreshTokenDb;
    }

    public async Task Handle(LogoutCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.RefreshToken))
            throw new ArgumentException("Refresh token canot be empty", nameof(request.RefreshToken));

        var storedToken = await _refreshTokenDb.RefreshTokens
            .SingleOrDefaultAsync(rt => rt.Token == request.RefreshToken, cancellationToken);

        // Idempotent logout: nothing to revoke if the token is unknown or already revoked.
        if (storedToken is null || storedToken.RevokedAt is not null)
            return;

        storedToken.RevokedAt = DateTime.UtcNow;

        await _refreshTokenDb.SaveChangesAsync(cancellationToken);
    }
}
