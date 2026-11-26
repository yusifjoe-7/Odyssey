using Odyssey.Domain.Users.Admins;

namespace Odyssey.Domain.Hosts;

public class ApprovedAddHostRequest
{
    public int Id { get; set; }

    public int HostId { get; set; }
    public Host host { get; set; }

    public int AdminId { get; set; }  // The Admin Who Approved
    public Admin admin { get; set; }
}
