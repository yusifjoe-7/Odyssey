using Microsoft.EntityFrameworkCore;
using Odyssey.Domain.Reviews.Hosts;

namespace Odyssey.Application.Common.Persistence.Interfaces;

public interface IHostReviewDb
{
    DbSet<HostReview> HostReviews { get; }
    Task<int> SaveChangesAsync(CancellationToken ct = default);
}