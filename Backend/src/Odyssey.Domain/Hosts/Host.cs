using System;
using Odyssey.Domain.Users.Owners;

namespace Odyssey.Domain.Hosts;

public class Host
{
    public Guid Id { get; set; }

    public string OwnerUserName { get; set; }
    public Owner Owner { get; set; }

    public string Description { get; set; }

    public decimal PricePerNight { get; set; }

    public int PropertyArea { get; set; }

    public string MainImageKey { get; set; }

    public ICollection<HostImages> HostImages { get; set; } = new List<HostImages>();

}
