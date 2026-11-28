using Microsoft.AspNetCore.Http;

namespace Odyssey.Application.Common.Storage;

public interface IUploadFileStorage
{
    Task<string> UploadAsync(IFormFile file, CancellationToken cancellationToken = default);
}
