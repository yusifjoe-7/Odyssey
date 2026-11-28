using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Minio;
using Minio.DataModel.Args;
using Odyssey.Application.Common.Storage;

namespace Odyssey.Infrastructure.Storage;

public class MinioUploadFileStorage : IUploadFileStorage
{
    private readonly IMinioClient _minio;
    private readonly string _bucketName;

    public MinioUploadFileStorage(IMinioClient minio, IConfiguration configuration)
    {
        _minio = minio;
        _bucketName = configuration["Minio:BucketName"] ?? "odyssey";
    }

    public async Task<string> UploadAsync(IFormFile file, CancellationToken cancellationToken = default)
    {
        var objectName = $"{Guid.NewGuid():N}{Path.GetExtension(file.FileName)}";

        await using var stream = file.OpenReadStream();

        await _minio.PutObjectAsync(new PutObjectArgs()
            .WithBucket(_bucketName)
            .WithObject(objectName)
            .WithStreamData(stream)
            .WithObjectSize(file.Length)
            .WithContentType(file.ContentType), cancellationToken);

        return objectName;
    }
}
