using Microsoft.Extensions.Configuration;
using Minio;
using Minio.DataModel.Args;
using Odyssey.Application.Common.Storage;

namespace Odyssey.Infrastructure.Storage;

public class MinioGetFileStorage : IGetFileStorage
{
    private const int PresignedExpirySeconds = 3600;

    private readonly IMinioClient _minio;
    private readonly string _bucketName;

    public MinioGetFileStorage(IMinioClient minio, IConfiguration configuration)
    {
        _minio = minio;
        _bucketName = configuration["Minio:BucketName"] ?? "odyssey";
    }

    public Task<string> GetAsync(string key, CancellationToken cancellationToken = default)
        => _minio.PresignedGetObjectAsync(new PresignedGetObjectArgs()
            .WithBucket(_bucketName)
            .WithObject(key)
            .WithExpiry(PresignedExpirySeconds));
}
