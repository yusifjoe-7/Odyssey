using Odyssey.Domain.Users.Owners;

namespace Odyssey.Domain.Hosts;

public class Host
{
    public int Id { get; set; }
    
    public int OwnerId { get; set; }
    public Owner owner { get; set; }

    public string Description { get; set; }

    
}
