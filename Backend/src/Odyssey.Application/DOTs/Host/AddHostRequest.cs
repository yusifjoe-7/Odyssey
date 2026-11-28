using Microsoft.AspNetCore.Http;

namespace Odyssey.Application.DOTs.Host;

public class AddHostRequest
{

    public required string OwnerUserName { get; set; }

    public required string Description { get; set; }

    public required decimal PricePerNight { get; set; }

    public required int PropertyArea { get; set; }

    public required IFormFile MainImageKey { get; set; }

    public List<IFormFile> HostImages { get; set; } 
}
