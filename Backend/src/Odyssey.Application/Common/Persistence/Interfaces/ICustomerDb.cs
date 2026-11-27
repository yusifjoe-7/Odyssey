using Microsoft.EntityFrameworkCore;
using Odyssey.Domain.Users.Customers;

namespace Odyssey.Application.Common.Persistence.Interfaces;

public interface ICustomerDb
{
    DbSet<Customer> Customers { get; }
    Task<int> SaveChangesAsync(CancellationToken ct = default);
}