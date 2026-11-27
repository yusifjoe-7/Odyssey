using Odyssey.Application.Common.Persistence.Interfaces;
using Odyssey.Application.Users.Registering;
using Odyssey.Domain.Users;
using Odyssey.Domain.Users.Owners;

namespace Odyssey.Application.Users.Owners;

public class OwnerDbRegisteringCommit(IOwnerDb context) : IDbRegisteringCommit
{
    public async Task<int> Commit(User user, CancellationToken cancellationToken)
    {
        user.role = Role.Owner;
        
        context.Owners.Add((Owner)user);

        await context.SaveChangesAsync(cancellationToken);
        return user.Id;
    }
}
