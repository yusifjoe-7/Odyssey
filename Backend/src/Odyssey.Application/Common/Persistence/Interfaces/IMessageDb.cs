using Microsoft.EntityFrameworkCore;
using Odyssey.Domain.ChatSystem;

namespace Odyssey.Application.Common.Persistence.Interfaces;

public interface IMessageDb
{
    DbSet<Message> Messages { get; }
    Task<int> SaveChangesAsync(CancellationToken ct = default);
}