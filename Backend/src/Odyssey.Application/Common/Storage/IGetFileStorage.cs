namespace Odyssey.Application.Common.Storage;

public interface IGetFileStorage
{
    Task<string> GetAsync(string key, CancellationToken cancellationToken = default);
}
