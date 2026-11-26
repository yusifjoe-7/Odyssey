using Odyssey.Domain.Users;

namespace Odyssey.Domain.ChatSystem;

public class Message
{
    public int Id { get; set; }

    public int ConversationId { get; set; }
    public Conversation conversations { get; set; }

    public int SenderId { get; set; }
    public User Sender { get; set; }

    public int ReceiverId { get; set; }
    public User Receiver { get; set; }
}
