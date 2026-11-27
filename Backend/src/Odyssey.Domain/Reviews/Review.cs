using Odyssey.Domain.Users;

namespace Odyssey.Domain.Reviews;

public class Review
{
    public int Id { get; set; }

    public string UserName { get; set; }

    public byte Rate { get; set; }
    public string Description { get; set; }
}
