using HBS.Core.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HBS.Data;

public class HotelContext : DbContext
{
    public const string ConnectionStringName = "HotelDb";

    public HotelContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<HotelModel> Hotels { get; set; }

    public static void Configure(DbContextOptionsBuilder optionsBuilder, IConfiguration configuration)
    {
        optionsBuilder.UseNpgsql(configuration.GetConnectionString(ConnectionStringName));
    }
}