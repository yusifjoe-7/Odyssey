using Microsoft.EntityFrameworkCore;
using Odyssey.Domain.Users.Owners;

namespace Odyssey.Application.Common.Persistence.Interfaces;

public interface IOwnerDb
{
    DbSet<Owner> Owners { get; }
    Task<int> SaveChangesAsync(CancellationToken ct = default);
}