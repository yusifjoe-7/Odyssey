using MediatR;
using Microsoft.AspNetCore.Http;

namespace Odyssey.Application.Host.Add;

public record AddHostRequestCommand(
    string OwnerUserName,
    string Description,
    decimal PricePerNight,
    int PropertyArea,
    IFormFile MainImageKey,
    List<IFormFile> HostImages
) : IRequest;
