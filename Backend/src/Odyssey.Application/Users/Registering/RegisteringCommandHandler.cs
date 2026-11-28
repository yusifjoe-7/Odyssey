using System.Diagnostics;
using MediatR;
using Odyssey.Application.Common.Storage;
using Odyssey.Application.Exceptons;
using Odyssey.Domain.Common.Security;
using Odyssey.Domain.Users;
using Odyssey.Domain.Users.Admins;
using Odyssey.Domain.Users.Customers;
using Odyssey.Domain.Users.Owners;
using Odyssey.Application.Users.Admins.Registering;
using Odyssey.Application.Users.Owners.Registering;
using Odyssey.Application.Users.Customers.Registering;

namespace Odyssey.Application.Users.Registering;

public class RegisteringCommandHandler : IRequestHandler<RegisteringCommand, int>
{


    private readonly CustomerDbRegisteringCommit _customerCommit;
    private readonly OwnerDbRegisteringCommit _ownerCommit;
    private readonly AdminDbRegisteringCommit _adminCommit;
    private readonly IUploadFileStorage _uploadFileStorage;

    public RegisteringCommandHandler(
        CustomerDbRegisteringCommit customerCommit,
        OwnerDbRegisteringCommit ownerCommit,
        AdminDbRegisteringCommit adminCommit,
        IUploadFileStorage uploadFileStorage)
    {
        _customerCommit = customerCommit;
        _ownerCommit = ownerCommit;
        _adminCommit = adminCommit;
        _uploadFileStorage = uploadFileStorage;
    }


    public async Task<int> Handle(RegisteringCommand registeringCommand, CancellationToken cancellationToken)
    {
        var hashed = PasswordHasher.Hash(registeringCommand.Password);

        User user = registeringCommand.Role switch
        {
            "Customer" => new Customer
            {
                Name = $"{registeringCommand.FristName} {registeringCommand.SecondName}",
                UserName = registeringCommand.UserName,
                Email = registeringCommand.Email,
                HashedPassword = hashed,
            },
            "Owner" => new Owner
            {
                Name = $"{registeringCommand.FristName} {registeringCommand.SecondName}",
                UserName = registeringCommand.UserName,
                Email = registeringCommand.Email,
                HashedPassword = hashed,
            },
            "Admin" => new CreateAdminRequest
            {
                Name = $"{registeringCommand.FristName} {registeringCommand.SecondName}",
                UserName = registeringCommand.UserName,
                Email = registeringCommand.Email,
                HashedPassword = hashed,
            },
            _ => throw new UnkownRoleException($"What Is {registeringCommand.Role}")
        };

        IDbRegisteringCommit Commiter = registeringCommand.Role switch
        {
            "Customer" => _customerCommit,
            "Owner"    => _ownerCommit,
            "Admin"    => _adminCommit,
            _ => throw new UnkownRoleException($"What Is {registeringCommand.Role}")
        };

        // Add the Image for everyone except Admin, right after the switch.
        if (registeringCommand.Role != "Admin")
        {
            var imageKey = registeringCommand.Image is null
                ? null
                : await _uploadFileStorage.UploadAsync(registeringCommand.Image, cancellationToken);

            ((Client)user).ImageKey = imageKey;
        }

        return await Commiter.Commit(user, cancellationToken);
    }
}
