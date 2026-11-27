using MediatR;

namespace Odyssey.Application.Users.Logout;

public record LogoutCommand(string RefreshToken) : IRequest;
