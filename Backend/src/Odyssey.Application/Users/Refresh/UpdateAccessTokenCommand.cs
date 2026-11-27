using MediatR;

namespace Odyssey.Application.Users.Refresh;

public record UpdateAccessTokenCommand(string RefreshToken) : IRequest<UpdateAccessTokenResult>;
