using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace BuildMyPcApi.Database;

public class BuildMyPcDbContextFactory : IDesignTimeDbContextFactory<BuildMyPcDbContext>
{
    public BuildMyPcDbContext CreateDbContext(string[] args)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<BuildMyPcDbContext>();
        optionsBuilder.UseSqlServer(config.GetConnectionString("BuildMyPcApiDatabase"));

        return new BuildMyPcDbContext(optionsBuilder.Options);
    }
}
