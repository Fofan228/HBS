using System.Reflection;
using System.Globalization;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using HBS.Core.Entities;

namespace HBS.Data;

public class HotelContext : DbContext
{
    public const string ConnectionStringName = "HotelDb";

    public HotelContext(DbContextOptions options) : base(options) { }

    public DbSet<Hotel> Hotels { get; set; } = null!;

    public static void Configure(
        DbContextOptionsBuilder optionsBuilder,
        IConfiguration configuration,
        Assembly? migrationAssembly = null)
    {
        optionsBuilder.UseNpgsql(configuration.GetConnectionString(ConnectionStringName), b =>
        {
            if (migrationAssembly != null) b.MigrationsAssembly(migrationAssembly.FullName);
        })
        .UseCamelCaseNamingConvention(CultureInfo.InvariantCulture);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(HotelContext).Assembly);
    }
}