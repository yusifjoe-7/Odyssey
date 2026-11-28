using Microsoft.AspNetCore.Http;

namespace Odyssey.Application.DOTs.Auth;

public class RegisterUserRequest
{
    public required string FirestName { get; set; }
    public required string SecondName { get; set; }
    public required string UserName { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }

    public IFormFile? Image { get; set; }
}
