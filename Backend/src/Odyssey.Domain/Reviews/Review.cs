using Odyssey.Domain.Users;

namespace Odyssey.Domain.Reviews;

public class Review
{
    public int Id { get; set; }

    public int FromId { get; set; }
    public User FromUser { get; set; }

    public byte Rate { get; set; }
    public string Description { get; set; }
}
