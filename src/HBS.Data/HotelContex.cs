using Microsoft.EntityFrameworkCore;
using HBS.Core.Models;
using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace HBS.Data
{

    public class HotelContext : DbContext
    {
        public DbSet<HotelModel> Hotels { get; set; }
        public DbSet<NearbyPlaceModel> NearbyPlaces { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=postgres;Database=postgres;");
        }
    }
}