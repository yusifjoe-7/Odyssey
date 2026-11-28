using MediatR;
using Odyssey.Application.DOTs.Auth;

namespace Odyssey.Application.Users.Login;

public record LoginCommand(string UserName, string Password) : IRequest<LoginResult>;
