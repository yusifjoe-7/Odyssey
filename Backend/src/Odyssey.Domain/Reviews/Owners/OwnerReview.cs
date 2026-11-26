using Odyssey.Domain.Users.Owners;

namespace Odyssey.Domain.Reviews.Owners;

public class OwnerReview : Review
{
    public int ToId { get; set; }
    public Owner ToOwner { get; set; }
}
