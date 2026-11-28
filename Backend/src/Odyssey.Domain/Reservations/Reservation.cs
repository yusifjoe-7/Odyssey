using System;
using Odyssey.Domain.Users.Customers;
using Odyssey.Domain.Users.Owners;
using Odyssey.Domain.Hosts;

namespace Odyssey.Domain.Reservations;

public class Reservation
{
    // this UUID becuase i think the user will need it in case somthing went wrong, to make a report 
    public Guid Id { get; set; }
    
    public string OwnerUserName { get; set; }
    public Owner Owner { get; set; }

    public string CustomerUserName { get; set; }
    public Customer customer { get; set; }
    
    public Guid HostId { get; set; }
    public Host host { get; set; }

    public decimal TotalPrice { get; set; }

    public DateOnly From { get; set; }
    public DateOnly To { get; set; }
}
