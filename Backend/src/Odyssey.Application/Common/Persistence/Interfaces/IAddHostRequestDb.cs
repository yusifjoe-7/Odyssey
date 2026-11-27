using Microsoft.EntityFrameworkCore;
using Odyssey.Domain.Hosts;

namespace Odyssey.Application.Common.Persistence.Interfaces;

public interface IAddHostRequestDb
{
    DbSet<AddHostRequest> AddHostRequests { get; }
    Task<int> SaveChangesAsync(CancellationToken ct = default);
}