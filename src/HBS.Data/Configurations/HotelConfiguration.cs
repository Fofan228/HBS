using HBS.Core.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HBS.Data.Configurations;

public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
{
    public void Configure(EntityTypeBuilder<Hotel> builder)
    {
        builder.Property(h => h.Address).IsRequired();
        builder.Property(h => h.Name).IsRequired();
        builder.Property(h => h.Rating).IsRequired();
        builder.OwnsOne(h => h.Coordinates, b =>
        {
            b.Property(c => c.Longitude).IsRequired();
            b.Property(c => c.Latitude).IsRequired();
        });
    }
}