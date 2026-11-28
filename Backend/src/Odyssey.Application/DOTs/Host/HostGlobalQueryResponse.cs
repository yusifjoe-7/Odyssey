namespace Odyssey.Application.DOTs.Host;

public class HostGlobalQueryResponse
{
    public IReadOnlyList<Odyssey.Domain.Hosts.Host> Hosts { get; set; } = new List<Odyssey.Domain.Hosts.Host>();

    public Guid? LastElement { get; set; }
}
