using Odyssey.Domain.Users.Owners;
using Odyssey.Domain.Common;

namespace Odyssey.Domain.Hosts;

public class AddHostRequest
{
    public int Id { get; set; }
    
    public string OwnerUserName { get; set; }
    public Owner Owner { get; set; }

    public string Description { get; set; }

    public AddRequestState Situation { get; set; } = AddRequestState.WAITING;

    public ICollection<HostImages> HostImages { get; set; } = new List<HostImages>();
}
