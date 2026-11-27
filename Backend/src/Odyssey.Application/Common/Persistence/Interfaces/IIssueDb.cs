using Microsoft.EntityFrameworkCore;
using Odyssey.Domain.Support;

namespace Odyssey.Application.Common.Persistence.Interfaces;

public interface IIssueDb
{
    DbSet<Issue> Issues { get; }
    Task<int> SaveChangesAsync(CancellationToken ct = default);
}