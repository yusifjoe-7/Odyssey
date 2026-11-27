using MediatR;
using Microsoft.EntityFrameworkCore;
using Odyssey.Application.Common.Auth;
using Odyssey.Application.Common.Persistence.Interfaces;
using Odyssey.Domain.Exceptions;
using Odyssey.Domain.Users;

namespace Odyssey.Application.Users.Refresh;

public class UpdateAccessTokenCommandHandler : IRequestHandler<UpdateAccessTokenCommand, UpdateAccessTokenResult>
{
    private const int RefreshTokenExpirationDays = 7;

    private readonly IRefreshTokenDb _refreshTokenDb;
    private readonly ITokenService _tokenService;

    public UpdateAccessTokenCommandHandler(IRefreshTokenDb refreshTokenDb, ITokenService tokenService)
    {
        _refreshTokenDb = refreshTokenDb;
        _tokenService = tokenService;
    }

    public async Task<UpdateAccessTokenResult> Handle(UpdateAccessTokenCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.RefreshToken))
            throw new ArgumentException("Refresh token canot be empty", nameof(request.RefreshToken));

        var storedToken = await _refreshTokenDb.RefreshTokens
            .SingleOrDefaultAsync(rt => rt.Token == request.RefreshToken, cancellationToken)
            ?? throw new NotFoundException("Refresh token not found");

        if (storedToken.RevokedAt is not null)
            throw new System.ComponentModel.DataAnnotations.ValidationException("Refresh token has been revoked");

        if (storedToken.ExpiresAt <= DateTime.UtcNow)
            throw new System.ComponentModel.DataAnnotations.ValidationException("Refresh token has expired");

        var user = await _refreshTokenDb.FindUserAsync(storedToken.UserId, cancellationToken)
            ?? throw new NotFoundException($"User {storedToken.UserId} not found");

        // Rotate: revoke the presented token and issue a fresh refresh token.
        storedToken.RevokedAt = DateTime.UtcNow;

        var newRefreshToken = new RefreshToken
        {
            Token = _tokenService.CreateRefreshToken(),
            UserId = user.Id,
            CreatedAt = DateTime.UtcNow,
            ExpiresAt = DateTime.UtcNow.AddDays(RefreshTokenExpirationDays),
            RevokedAt = null
        };

        _refreshTokenDb.RefreshTokens.Add(newRefreshToken);
        await _refreshTokenDb.SaveChangesAsync(cancellationToken);

        var accessToken = _tokenService.CreateAccessToken(user);

        return new UpdateAccessTokenResult(accessToken, newRefreshToken.Token);
    }
}
