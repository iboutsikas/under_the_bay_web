// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NodaTime;
using Under_the_Bay.Data;

namespace Under_the_Bay.API.Migrations
{
    [DbContext(typeof(UtbContext))]
    [Migration("20210601205641_Add model validations")]
    partial class Addmodelvalidations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "6.0.0-preview.4.21253.1")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Under_the_Bay.Data.Models.Sample", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<float>("BlueGreenAlgae")
                        .HasColumnType("real");

                    b.Property<float>("Chlorophyll")
                        .HasColumnType("real");

                    b.Property<float>("DissolvedOxygen")
                        .HasColumnType("real");

                    b.Property<float>("DissolvedOxygenSaturation")
                        .HasColumnType("real");

                    b.Property<float>("Salinity")
                        .HasColumnType("real");

                    b.Property<Instant>("SampleDate")
                        .HasColumnType("timestamp");

                    b.Property<float>("SampleDepth")
                        .HasColumnType("real");

                    b.Property<Guid>("StationId")
                        .HasColumnType("uuid");

                    b.Property<float>("Turbidity")
                        .HasColumnType("real");

                    b.Property<float>("WaterTemperature")
                        .HasColumnType("real");

                    b.Property<float>("pH")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("StationId");

                    b.ToTable("Samples");
                });

            modelBuilder.Entity("Under_the_Bay.Data.Models.Station", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Instant>("LastUpdate")
                        .HasColumnType("timestamp");

                    b.Property<string>("Layer")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("StationId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ThreeLetterId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Stations");
                });

            modelBuilder.Entity("Under_the_Bay.Data.Models.Sample", b =>
                {
                    b.HasOne("Under_the_Bay.Data.Models.Station", "Station")
                        .WithMany("Samples")
                        .HasForeignKey("StationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Station");
                });

            modelBuilder.Entity("Under_the_Bay.Data.Models.Station", b =>
                {
                    b.Navigation("Samples");
                });
#pragma warning restore 612, 618
        }
    }
}
