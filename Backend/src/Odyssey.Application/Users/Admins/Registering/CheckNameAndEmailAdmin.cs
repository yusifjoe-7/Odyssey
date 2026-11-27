using Odyssey.Application.Common.Persistence.Interfaces;
using Odyssey.Application.Exceptons;
using Odyssey.Application.Users.Registering;
using Odyssey.Domain.Users;

namespace Odyssey.Application.Users.Admins.Registering;

public class CheckNameAndEmailAdmin(IAdminDb context)
{
    public async Task Check(User user)
    {

        // get bouth in one query for butter performance
        var results = context.Admins.Where(a => a.Email == user.Email || a.UserName == user.UserName );
        
        ExistChecks.Check(results, user);
    }
}
