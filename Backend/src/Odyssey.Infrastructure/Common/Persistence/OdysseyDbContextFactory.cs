using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Odyssey.Infrastructure.Common.Persistence;

public class OdysseyDbContextFactory : IDesignTimeDbContextFactory<OdysseyDbContext>
{
    public OdysseyDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
            .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: false)
            .AddEnvironmentVariables()
            .Build();

        var connectionString = configuration.GetConnectionString("DefaultConnection")
            ?? "Host=localhost;Database=Odyssey;Username=joe;Password=12345sbcdf;";

        var optionsBuilder = new DbContextOptionsBuilder<OdysseyDbContext>();
        optionsBuilder.UseNpgsql(connectionString);

        return new OdysseyDbContext(optionsBuilder.Options);
    }
}
