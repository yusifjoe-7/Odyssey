using System.Diagnostics;
using MediatR;
using Odyssey.Application.Exceptons;
using Odyssey.Domain.Common.Security;
using Odyssey.Domain.Users;
using Odyssey.Application.Users.Admins.Registering;
using Odyssey.Application.Users.Owners.Registering;
using Odyssey.Application.Users.Customers.Registering;

namespace Odyssey.Application.Users.Registering;

public class RegisteringCommandHandler : IRequestHandler<RegisteringCommand, int>
{

    
    private readonly CustomerDbRegisteringCommit _customerCommit;
    private readonly OwnerDbRegisteringCommit _ownerCommit;
    private readonly AdminDbRegisteringCommit _adminCommit;

    public RegisteringCommandHandler(
        CustomerDbRegisteringCommit customerCommit,
        OwnerDbRegisteringCommit ownerCommit,
        AdminDbRegisteringCommit adminCommit)
    {
        _customerCommit = customerCommit;
        _ownerCommit = ownerCommit;
        _adminCommit = adminCommit;
    }


    public async Task<int> Handle(RegisteringCommand registeringCommand, CancellationToken cancellationToken)
    {
        var hashed = PasswordHasher.Hash(registeringCommand.Password);

        User user = new User
        {
            Name = $"{registeringCommand.FristName} {registeringCommand.SecondName}",
            UserName = registeringCommand.UserName,
            Email = registeringCommand.Email,
            HashedPassword = hashed,
        };

        IDbRegisteringCommit Commiter = registeringCommand.Role switch
        {
            "Customer" => _customerCommit,
            "Owner"    => _ownerCommit,
            "Admin"    => _adminCommit,
            _ => throw new UnkownRoleException($"What Is {registeringCommand.Role}")
        };


        return await Commiter.Commit(user, cancellationToken);
    }
}
