using System;
using Odyssey.Application.Common.Persistence.Interfaces;
using Odyssey.Application.Users.Registering;
using Odyssey.Domain.Users;
using Odyssey.Domain.Users.Customers;

namespace Odyssey.Application.Users.Customers.Registering;


public class CustomerDbRegisteringCommit(ICustomerDb context, CheckNameAndEmailCustomer Checker) : IDbRegisteringCommit
{
    public async Task<Guid> Commit(User user, CancellationToken cancellationToken)
    {
        await Checker.Check(user);

        user.role = Role.Owner;

        context.Customers.Add((Customer)user);

        await context.SaveChangesAsync(cancellationToken);
        return user.Id;
    }
}