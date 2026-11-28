
namespace Odyssey.Infrastructure;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Minio;
using Odyssey.Application.Common.Auth;
using Odyssey.Application.Common.Persistence.Interfaces;
using Odyssey.Application.Common.Storage;
using Odyssey.Infrastructure.Auth;
using Odyssey.Infrastructure.Common.Persistence;
using Odyssey.Infrastructure.Storage;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<OdysseyDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<ITokenService, TokenService>();

        services.AddScoped<IRefreshTokenDb>(sp => sp.GetRequiredService<OdysseyDbContext>());

        services.AddScoped<IUserDb>(sp => sp.GetRequiredService<OdysseyDbContext>());

        var minioSection = configuration.GetSection("Minio");

        services.AddSingleton<IMinioClient>(_ =>
            new MinioClient()
                .WithEndpoint(minioSection["Endpoint"] ?? "localhost:9000")
                .WithCredentials(minioSection["AccessKey"] ?? "minioadmin", minioSection["SecretKey"] ?? "minioadmin")
                .WithSSL(bool.TryParse(minioSection["Secure"], out var secure) && secure)
                .Build());

        services.AddScoped<IUploadFileStorage, MinioUploadFileStorage>();

        return services;
    }
}