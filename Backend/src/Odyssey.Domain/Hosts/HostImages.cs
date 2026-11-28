namespace Odyssey.Domain.Hosts;

public class HostImages
{
    public int Id { get; set; }

    public string? ImageKey { get; set; }

    public int HostId { get; set; }
    public Host Host { get; set; }
}
