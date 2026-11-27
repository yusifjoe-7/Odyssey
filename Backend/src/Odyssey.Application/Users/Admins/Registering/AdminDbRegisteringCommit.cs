using Odyssey.Application.Common.Persistence.Interfaces;
using Odyssey.Application.Users.Registering;
using Odyssey.Domain.Users;
using Odyssey.Domain.Users.Admins;
using Odyssey.Application.Users.Admins.Registering;

namespace Odyssey.Application.Users.Admins.Registering;

public class AdminDbRegisteringCommit(IAdminDb context, CheckNameAndEmailAdmin Checker) : IDbRegisteringCommit
{
    public async Task<int> Commit(User user, CancellationToken cancellationToken)
    {
        await Checker.Check(user);

        user.role = Role.Owner;

        context.Admins.Add((Admin)user);

        await context.SaveChangesAsync(cancellationToken);
        return user.Id;
    }
}
