using Odyssey.Application.Common.Persistence.Interfaces;
using Odyssey.Application.Users.Registering;
using Odyssey.Domain.Users;
using Odyssey.Domain.Users.Customers;

namespace Odyssey.Application.Users.Customers;

public class CustomerDbRegisteringCommit(ICustomerDb context) : IDbRegisteringCommit
{
    public async Task<int> Commit(User user, CancellationToken cancellationToken)
    {

        user.role = Role.Customer;
        
        context.Customers.Add((Customer)user);

        await context.SaveChangesAsync(cancellationToken);
        return user.Id;
    }
}