using Microsoft.EntityFrameworkCore;
using Odyssey.Domain.Reservations;

namespace Odyssey.Application.Common.Persistence.Interfaces;

public interface IReservationDb
{
    DbSet<Reservation> Reservations { get; }
    Task<int> SaveChangesAsync(CancellationToken ct = default);
}