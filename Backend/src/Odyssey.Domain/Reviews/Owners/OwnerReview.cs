using Odyssey.Domain.Users.Owners;

namespace Odyssey.Domain.Reviews.Owners;

public class OwnerReview : Review
{
    public string ToOwnerUserName { get; set; }
    public Owner ToOwner { get; set; }
}
