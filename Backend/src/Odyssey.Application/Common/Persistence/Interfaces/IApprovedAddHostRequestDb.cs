using Microsoft.EntityFrameworkCore;
using Odyssey.Domain.Hosts;

namespace Odyssey.Application.Common.Persistence.Interfaces;

public interface IApprovedAddHostRequestDb
{
    DbSet<ApprovedAddHostRequest> ApprovedAddHostRequests { get; }
    Task<int> SaveChangesAsync(CancellationToken ct = default);
}