using HBS.Data;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace HBS.Migrations;

public class Factory : IDesignTimeDbContextFactory<HotelContext>
{
    public HotelContext CreateDbContext(string[] args)
    {
        var configurationBuilder = new ConfigurationBuilder()
            .AddEnvironmentVariables()
            .AddUserSecrets<Factory>();

        var configuration = configurationBuilder.Build();
        var optionsBuilder = new DbContextOptionsBuilder<HotelContext>();
        HotelContext.Configure(optionsBuilder, configuration, typeof(Factory).Assembly);

        return new HotelContext(optionsBuilder.Options);
    }
}