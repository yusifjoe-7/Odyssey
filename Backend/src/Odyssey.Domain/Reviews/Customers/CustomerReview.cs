using Odyssey.Domain.Users.Customers;

namespace Odyssey.Domain.Reviews.Customers;

public class CustomerReview : Review
{
    public string ToCustomerUserName { get; set; }
    public Customer ToCustomer { get; set; }
}
