using Microsoft.EntityFrameworkCore;
using Odyssey.Domain.Hosts;

namespace Odyssey.Application.Common.Persistence.Interfaces;

public interface IHostDb
{
    DbSet<Host> Hosts { get; }
    Task<int> SaveChangesAsync(CancellationToken ct = default);
}