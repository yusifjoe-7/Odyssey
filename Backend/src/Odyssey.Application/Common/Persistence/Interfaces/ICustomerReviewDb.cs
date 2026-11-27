using Microsoft.EntityFrameworkCore;
using Odyssey.Domain.Reviews.Customers;

namespace Odyssey.Application.Common.Persistence.Interfaces;

public interface ICustomerReviewDb
{
    DbSet<CustomerReview> CustomerReviews { get; }
    Task<int> SaveChangesAsync(CancellationToken ct = default);
}