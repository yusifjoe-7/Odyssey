using System;
using Odyssey.Domain.Users;

namespace Odyssey.Domain.ChatSystem;

public class Message
{
    public Guid Id { get; set; }

    public Guid ConversationId { get; set; }
    public Conversation conversations { get; set; }

    public Guid SenderId { get; set; }

    public Guid ReceiverId { get; set; }
}
