using Microsoft.EntityFrameworkCore;
using Odyssey.Domain.ChatSystem;

namespace Odyssey.Application.Common.Persistence.Interfaces;

public interface IConversationDb
{
    DbSet<Conversation> Conversations { get; }
    Task<int> SaveChangesAsync(CancellationToken ct = default);
}