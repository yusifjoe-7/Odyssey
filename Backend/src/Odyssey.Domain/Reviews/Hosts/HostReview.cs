using System;
using Odyssey.Domain.Hosts;

namespace Odyssey.Domain.Reviews.Hosts;

public class HostReview : Review
{
    public Guid ToId { get; set; }
    public Host ToHost { get; set; }
}
