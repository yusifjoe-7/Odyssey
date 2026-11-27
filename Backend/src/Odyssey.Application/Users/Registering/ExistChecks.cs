using Odyssey.Application.Exceptons;
using Odyssey.Domain.Users;

namespace Odyssey.Application.Users.Registering;

public static class ExistChecks
{
    public static void Check(IQueryable<User>  results, User user )
    {
        foreach (var res in results)
        {
            if (res.Email == user.Email)
                throw new EmailAlreadyExistsException("this email already exists");
            else if (res.UserName == user.UserName)
                throw new UserNameAlreadyExistsExeption("this UserName already exist");
        }
    }
}
