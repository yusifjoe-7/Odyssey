using MediatR;

namespace Odyssey.Application.Users.Login;

public record LoginCommand(string UserName, string Password) : IRequest<LoginResult>;
