using System;
using Odyssey.Application.Common.Persistence.Interfaces;
using Odyssey.Application.Users.Registering;
using Odyssey.Domain.Users;
using Odyssey.Domain.Users.Owners;

namespace Odyssey.Application.Users.Owners.Registering;

public class OwnerDbRegisteringCommit(IOwnerDb context, CheckNameAndEmailOwner Checker) : IDbRegisteringCommit
{
    public async Task<Guid> Commit(User user, CancellationToken cancellationToken)
    {
        await Checker.Check(user);

        user.role = Role.Owner;

        context.Owners.Add((Owner)user);

        await context.SaveChangesAsync(cancellationToken);
        return user.Id;
    }
}
