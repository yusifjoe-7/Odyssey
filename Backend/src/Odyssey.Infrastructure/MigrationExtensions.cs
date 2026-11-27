
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Odyssey.Infrastructure.Common.Persistence;

public static class MigrationExtensions
{
    public static async Task ApplyMigrationsAsync(this IServiceProvider services)
    {
        using var scope = services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<OdysseyDbContext>();
        await db.Database.MigrateAsync();
    }
}
