namespace Odyssey.Application.DOTs.Users;

public class RegisterUserRequest
{
    public required string FirestName { get; set; }
    public required string SecondName { get; set; }
    public required string UserName { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
}
