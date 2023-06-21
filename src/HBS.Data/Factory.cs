using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace HBS.Data;

public class Factory : IDesignTimeDbContextFactory<HotelContext>
{
    public HotelContext CreateDbContext(string[] args)
    {
        var configurationBuilder = new ConfigurationBuilder()
            .AddUserSecrets<Factory>();

        var configuration = configurationBuilder.Build();
        var optionsBuilder = new DbContextOptionsBuilder<HotelContext>();
        HotelContext.Configure(optionsBuilder, configuration);

        return new HotelContext(optionsBuilder.Options);
    }
}