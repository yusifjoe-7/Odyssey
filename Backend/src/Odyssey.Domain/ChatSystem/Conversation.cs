using System;
using Odyssey.Domain.Reservations;
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

    public Guid ReservationId { get; set; }
    public Reservation Reservation { get; set; }
}
