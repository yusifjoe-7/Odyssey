using Odyssey.Application.Common.Persistence.Interfaces;
using Odyssey.Application.Users.Registering;
using Odyssey.Domain.Users;

namespace Odyssey.Application.Users.Owners.Registering;

public class CheckNameAndEmailOwner(IOwnerDb context)
{
    public async Task Check(User user)
    {

        // get bouth in one query for butter performance
        var results = context.Owners.Where(a => a.Email == user.Email || a.UserName == user.UserName );
        ExistChecks.Check(results, user);
    }
}
