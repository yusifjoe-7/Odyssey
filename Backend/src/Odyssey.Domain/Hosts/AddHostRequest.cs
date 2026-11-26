using Odyssey.Domain.Users.Owners;
using Odyssey.Domain.Common;

namespace Odyssey.Domain.Hosts;

public class AddHostRequest
{
    public int Id { get; set; }
    
    public int OwnerId { get; set; }
    public Owner owner { get; set; }

    public string Description { get; set; }

    public AddRequestState Situation { get; set; }
}
