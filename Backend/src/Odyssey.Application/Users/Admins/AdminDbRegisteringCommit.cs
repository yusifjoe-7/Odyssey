using Odyssey.Application.Common.Persistence.Interfaces;
using Odyssey.Application.Users.Registering;
using Odyssey.Domain.Users;
using Odyssey.Domain.Users.Admins;

namespace Odyssey.Application.Users.Admins;

public class AdminDbRegisteringCommit(IAdminDb context) : IDbRegisteringCommit
{
    public async Task<int> Commit(User user, CancellationToken cancellationToken)
    {
        user.role = Role.Owner;

        context.Admins.Add((Admin)user);

        await context.SaveChangesAsync(cancellationToken);
        return user.Id;
    }
}
