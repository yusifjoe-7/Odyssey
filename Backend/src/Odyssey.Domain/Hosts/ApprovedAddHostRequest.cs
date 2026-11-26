using Odyssey.Domain.Users.Admins;

namespace Odyssey.Domain.Hosts;

public class ApprovedAddHostRequest
{
    public int Id { get; set; }

    public int HostId { get; set; }
    public Host host { get; set; }

    public int ApprovedAdminId { get; set; }  // The Admin Who Approved
    public Admin ApprovedAdmin { get; set; }
}
