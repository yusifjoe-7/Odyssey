namespace Odyssey.Application.Common.Storage;

public interface IDeleteFileStorage
{
    Task DeleteAsync(string key, CancellationToken cancellationToken = default);
}
