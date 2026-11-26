using Odyssey.Domain.Common;

namespace Odyssey.Domain.Users.Admins;

public class CreateAdminRequest
{
    public int Id { get; set; }
    public User user { get; set; }
    public AddRequestState Situation { get; set; }

}
