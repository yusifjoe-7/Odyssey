using Odyssey.Domain.Users.Owners;

namespace Odyssey.Domain.Hosts;

public class Host
{
    public int Id { get; set; }
    
    public string OwnerUserName { get; set; }
    public Owner Owner { get; set; }

    public string Description { get; set; }

    
}
