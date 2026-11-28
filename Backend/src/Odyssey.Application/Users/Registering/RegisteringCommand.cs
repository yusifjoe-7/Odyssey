using System;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Odyssey.Application.Users.Registering;

public record RegisteringCommand(
            string FristName,
            string SecondName,
            string UserName,
            string Email,
            string Password,
            string Role,
            IFormFile? Image = null
            ) : IRequest<Guid>;
