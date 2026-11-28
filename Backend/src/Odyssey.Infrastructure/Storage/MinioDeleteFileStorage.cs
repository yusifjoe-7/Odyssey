using Microsoft.Extensions.Configuration;
using Minio;
using Minio.DataModel.Args;
using Odyssey.Application.Common.Storage;

namespace Odyssey.Infrastructure.Storage;

public class MinioDeleteFileStorage : IDeleteFileStorage
{
    private readonly IMinioClient _minio;
    private readonly string _bucketName;

    public MinioDeleteFileStorage(IMinioClient minio, IConfiguration configuration)
    {
        _minio = minio;
        _bucketName = configuration["Minio:BucketName"] ?? "odyssey";
    }

    public Task DeleteAsync(string key, CancellationToken cancellationToken = default)
        => _minio.RemoveObjectAsync(new RemoveObjectArgs()
            .WithBucket(_bucketName)
            .WithObject(key), cancellationToken);
}
