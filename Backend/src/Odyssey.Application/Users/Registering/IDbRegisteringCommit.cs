using System;
using Odyssey.Domain.Users;

namespace Odyssey.Application.Users.Registering;

public interface IDbRegisteringCommit
{
    public Task<Guid> Commit (User user, CancellationToken cancellationToken);
}
