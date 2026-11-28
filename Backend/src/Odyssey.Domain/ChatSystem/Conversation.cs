using System;
using Odyssey.Domain.Reservations;
using Odyssey.Domain.Users.Customers;
using Odyssey.Domain.Users.Owners;

namespace Odyssey.Domain.ChatSystem;

public class Conversation
{
    public Guid Id { get; set; }

    public Guid CustomerId { get; set; }
    public Customer customer { get; set; } 

    public Guid OwnerId { get; set; }
    public Owner owner { get; set; }

    public Guid ReservationId { get; set; }
    public Reservation Reservation { get; set; }
}
