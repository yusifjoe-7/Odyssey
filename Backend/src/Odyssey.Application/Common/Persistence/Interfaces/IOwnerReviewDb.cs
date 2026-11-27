using Microsoft.EntityFrameworkCore;
using Odyssey.Domain.Reviews.Owners;

namespace Odyssey.Application.Common.Persistence.Interfaces;

public interface IOwnerReviewDb
{
    DbSet<OwnerReview> OwnerReviews { get; }
    Task<int> SaveChangesAsync(CancellationToken ct = default);
}