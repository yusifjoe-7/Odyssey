using Odyssey.Domain.Users.Customers;
using Odyssey.Domain.Users.Owners;

namespace Odyssey.Domain.ChatSystem;

public class Conversation
{
    public int Id { get; set; }

    public int CustomerId { get; set; }
    public Customer customer { get; set; } 

    public int OwnerId { get; set; }
    public Owner owner { get; set; }

    public int ReservationId { get; set; }
    // add reservation object 
}
