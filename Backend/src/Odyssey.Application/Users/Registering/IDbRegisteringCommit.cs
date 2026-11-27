using Odyssey.Domain.Users;

namespace Odyssey.Application.Users.Registering;

public interface IDbRegisteringCommit
{
    public Task<int> Commit (User user, CancellationToken cancellationToken);
}
