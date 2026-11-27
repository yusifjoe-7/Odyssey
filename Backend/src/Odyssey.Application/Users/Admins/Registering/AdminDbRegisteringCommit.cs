using Odyssey.Application.Common.Persistence.Interfaces;
using Odyssey.Application.Users.Registering;
using Odyssey.Domain.Users;
using Odyssey.Domain.Users.Admins;
using Odyssey.Application.Users.Admins.Registering;

namespace Odyssey.Application.Users.Admins.Registering;

public class AdminDbRegisteringCommit(ICreateAdminRequestDb context, CheckNameAndEmailAdmin Checker1, CheckNameAndEmailAdminRequested Checker2) : IDbRegisteringCommit
{
    public async Task<int> Commit(User user, CancellationToken cancellationToken)
    {
        await Checker1.Check(user);
        await Checker2.Check(user);

        user.role = Role.Owner;
        

        context.CreateAdminRequests.Add((CreateAdminRequest)user);

        await context.SaveChangesAsync(cancellationToken);
        return user.Id;
    }
}
