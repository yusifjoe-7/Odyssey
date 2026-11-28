using Odyssey.Domain.Users;

namespace Odyssey.Application.Common.Persistence.Interfaces;

public interface IUserDb
{
    Task<User?> FindUserByUserNameAsync(string userName, CancellationToken cancellationToken = default);
}
