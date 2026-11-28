using System;
using Microsoft.EntityFrameworkCore;
using Odyssey.Domain.Users;

namespace Odyssey.Application.Common.Persistence.Interfaces;

public interface IRefreshTokenDb
{
    DbSet<RefreshToken> RefreshTokens { get; }

    Task<int> SaveChangesAsync(CancellationToken ct = default);

    Task<User?> FindUserAsync(Guid userId, CancellationToken cancellationToken = default);
}
