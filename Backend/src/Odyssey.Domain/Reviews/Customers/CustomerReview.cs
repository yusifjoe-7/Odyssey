using Odyssey.Domain.Users.Customers;

namespace Odyssey.Domain.Reviews.Customers;

public class CustomerReview : Review
{
    public int ToId { get; set; }
    public Customer ToUser { get; set; }
}
