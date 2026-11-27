using Microsoft.EntityFrameworkCore;
using Odyssey.Domain.Users.Admins;

namespace Odyssey.Application.Common.Persistence.Interfaces;

public interface IAdminDb
{
    DbSet<Admin> Admins { get; }
    Task<int> SaveChangesAsync(CancellationToken ct = default);
}