using Microsoft.EntityFrameworkCore;
using Odyssey.Domain.Users.Admins;

namespace Odyssey.Application.Common.Persistence.Interfaces;

public interface ICreateAdminRequestDb
{
    DbSet<CreateAdminRequest> CreateAdminRequests { get; }
    Task<int> SaveChangesAsync(CancellationToken ct = default);
}