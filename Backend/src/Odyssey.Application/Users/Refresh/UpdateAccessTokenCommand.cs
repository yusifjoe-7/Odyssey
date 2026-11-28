using MediatR;
using Odyssey.Application.DOTs.Auth;

namespace Odyssey.Application.Users.Refresh;

public record UpdateAccessTokenCommand(string RefreshToken) : IRequest<UpdateAccessTokenResult>;
