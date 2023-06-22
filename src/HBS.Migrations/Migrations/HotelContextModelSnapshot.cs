﻿// <auto-generated />
using HBS.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HBS.Migrations.Migrations
{
    [DbContext(typeof(HotelContext))]
    partial class HotelContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("HBS.Core.Entities.Hotel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("address");

                    b.Property<string>("LongDescription")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("longDescription");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string[]>("Photos")
                        .IsRequired()
                        .HasColumnType("text[]")
                        .HasColumnName("photos");

                    b.Property<double>("Rating")
                        .HasColumnType("double precision")
                        .HasColumnName("rating");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("shortDescription");

                    b.HasKey("Id")
                        .HasName("pK_hotels");

                    b.ToTable("hotels", (string)null);
                });

            modelBuilder.Entity("HBS.Core.Entities.Hotel", b =>
                {
                    b.OwnsOne("HBS.Core.Entities.Coordinates", "Coordinates", b1 =>
                        {
                            b1.Property<long>("HotelId")
                                .HasColumnType("bigint")
                                .HasColumnName("id");

                            b1.Property<double>("Latitude")
                                .HasColumnType("double precision")
                                .HasColumnName("coordinates_Latitude");

                            b1.Property<double>("Longitude")
                                .HasColumnType("double precision")
                                .HasColumnName("coordinates_Longitude");

                            b1.HasKey("HotelId");

                            b1.ToTable("hotels");

                            b1.WithOwner()
                                .HasForeignKey("HotelId")
                                .HasConstraintName("fK_hotels_hotels_id");
                        });

                    b.Navigation("Coordinates")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
