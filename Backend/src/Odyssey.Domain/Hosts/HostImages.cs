using System;
namespace Odyssey.Domain.Hosts;

public class HostImages
{
    public Guid Id { get; set; }

    public string? ImageKey { get; set; }

    public Guid HostId { get; set; }
    public Host Host { get; set; }
}
