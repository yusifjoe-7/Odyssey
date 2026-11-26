using Odyssey.Domain.Users.Customers;
using Odyssey.Domain.Users.Owners;
using Odyssey.Domain.Hosts;

namespace Odyssey.Domain.Reservations;

public class Reservation
{
    public int Id { get; set; }
    
    public int OwnerId { get; set; }
    public Owner owner { get; set; }

    public int CustomerId { get; set; }
    public Customer customer{ get; set; }
    
    public int HostId { get; set; }
    public Host host { get; set; }

    public DateOnly From { get; set; }
    public DateOnly To { get; set; }
}
