
namespace Odyssey.Infrastructure;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Odyssey.Application.Common.Auth;
using Odyssey.Application.Common.Persistence.Interfaces;
using Odyssey.Infrastructure.Auth;
using Odyssey.Infrastructure.Common.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<OdysseyDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<ITokenService, TokenService>();

        services.AddScoped<IRefreshTokenDb>(sp => sp.GetRequiredService<OdysseyDbContext>());

        return services;
    }
}