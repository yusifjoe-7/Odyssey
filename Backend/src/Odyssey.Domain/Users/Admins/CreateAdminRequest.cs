using Odyssey.Domain.Common;

namespace Odyssey.Domain.Users.Admins;

public class CreateAdminRequest : User
{
    public AddRequestState Situation { get; set; } = AddRequestState.WAITING;

    public string? ApprovedWithCode {get; set;}

}
