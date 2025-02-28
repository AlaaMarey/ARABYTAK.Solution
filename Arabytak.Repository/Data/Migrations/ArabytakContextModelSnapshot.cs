﻿// <auto-generated />
using System;
using Arabytak.Repository.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Arabytak.Repository.Data.Migrations
{
    [DbContext(typeof(ArabytakContext))]
    partial class ArabytakContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Arabytak.Core.Entities.AdPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("planType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("adplan");
                });

            modelBuilder.Entity("Arabytak.Core.Entities.Advertisement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AdPlanId")
                        .HasColumnType("int");

                    b.Property<int?>("CarId")
                        .HasColumnType("int");

                    b.Property<string>("ContactInfo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("SellerEmail")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("StartCreateAdvertisement")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AdPlanId");

                    b.HasIndex("CarId")
                        .IsUnique()
                        .HasFilter("[CarId] IS NOT NULL");

                    b.ToTable("advertisements");
                });

            modelBuilder.Entity("Arabytak.Core.Entities.Brand", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PictureUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("Arabytak.Core.Entities.Car", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int?>("BrandId")
                        .HasColumnType("int");

                    b.Property<int?>("DealershipId")
                        .HasColumnType("int");

                    b.Property<int?>("ModelId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("SpecNewCarId")
                        .HasColumnType("int");

                    b.Property<int?>("SpecUsedCarId")
                        .HasColumnType("int");

                    b.Property<string>("condition")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("DealershipId");

                    b.HasIndex("ModelId");

                    b.HasIndex("SpecNewCarId")
                        .IsUnique()
                        .HasFilter("[SpecNewCarId] IS NOT NULL");

                    b.HasIndex("SpecUsedCarId")
                        .IsUnique()
                        .HasFilter("[SpecUsedCarId] IS NOT NULL");

                    b.ToTable("cars");
                });

            modelBuilder.Entity("Arabytak.Core.Entities.CarPictureUrl", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<string>("PictureUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.ToTable("carsPictureUrls");
                });

            modelBuilder.Entity("Arabytak.Core.Entities.Dealership", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Branch1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Branch2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Branch3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Facebook")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Instagram")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Phone1")
                        .HasColumnType("int");

                    b.Property<int?>("Phone2")
                        .HasColumnType("int");

                    b.Property<int?>("Phone3")
                        .HasColumnType("int");

                    b.Property<int?>("WhatsApp1")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("deals");
                });

            modelBuilder.Entity("Arabytak.Core.Entities.InsuranceCompany", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("insuranceCompanys");
                });

            modelBuilder.Entity("Arabytak.Core.Entities.MaintenanceCenter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AvailableServices")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("maintenanceCenter");
                });

            modelBuilder.Entity("Arabytak.Core.Entities.Model", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("models");
                });

            modelBuilder.Entity("Arabytak.Core.Entities.RescueCompany", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Phone1")
                        .HasColumnType("int");

                    b.Property<int?>("Phone2")
                        .HasColumnType("int");

                    b.Property<int?>("Phone3")
                        .HasColumnType("int");

                    b.Property<string>("Service1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Service2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Service3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Service4")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("rescueCompanys");
                });

            modelBuilder.Entity("Arabytak.Core.Entities.SpecNewCar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Acceleration")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("AssemblyCountry")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Drivetrain")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fuel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("FuelEfficiency")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Gears")
                        .HasColumnType("int");

                    b.Property<decimal>("GroundClearance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Height")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("HorsePower")
                        .HasColumnType("int");

                    b.Property<decimal>("Length")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("OriginCountry")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Seats")
                        .HasColumnType("int");

                    b.Property<int>("TopSpeed")
                        .HasColumnType("int");

                    b.Property<string>("Transmission")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TrunkSize")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Wheelbase")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Width")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("specNewCars");
                });

            modelBuilder.Entity("Arabytak.Core.Entities.SpecUsedCar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FuelType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ManufacturingYear")
                        .HasColumnType("int");

                    b.Property<decimal>("Mileage")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Transmission")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("specUsedCars");
                });

            modelBuilder.Entity("Arabytak.Core.Entities.Advertisement", b =>
                {
                    b.HasOne("Arabytak.Core.Entities.AdPlan", "planForAdvertisement")
                        .WithMany()
                        .HasForeignKey("AdPlanId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Arabytak.Core.Entities.Car", "Car")
                        .WithOne()
                        .HasForeignKey("Arabytak.Core.Entities.Advertisement", "CarId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Car");

                    b.Navigation("planForAdvertisement");
                });

            modelBuilder.Entity("Arabytak.Core.Entities.Car", b =>
                {
                    b.HasOne("Arabytak.Core.Entities.Brand", "brand")
                        .WithMany()
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Arabytak.Core.Entities.Dealership", "dealership")
                        .WithMany()
                        .HasForeignKey("DealershipId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Arabytak.Core.Entities.Model", "model")
                        .WithMany()
                        .HasForeignKey("ModelId");

                    b.HasOne("Arabytak.Core.Entities.SpecNewCar", "specNewCar")
                        .WithOne()
                        .HasForeignKey("Arabytak.Core.Entities.Car", "SpecNewCarId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Arabytak.Core.Entities.SpecUsedCar", "specUsedCar")
                        .WithOne()
                        .HasForeignKey("Arabytak.Core.Entities.Car", "SpecUsedCarId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("brand");

                    b.Navigation("dealership");

                    b.Navigation("model");

                    b.Navigation("specNewCar");

                    b.Navigation("specUsedCar");
                });

            modelBuilder.Entity("Arabytak.Core.Entities.CarPictureUrl", b =>
                {
                    b.HasOne("Arabytak.Core.Entities.Car", "car")
                        .WithMany("Url")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("car");
                });

            modelBuilder.Entity("Arabytak.Core.Entities.Car", b =>
                {
                    b.Navigation("Url");
                });
#pragma warning restore 612, 618
        }
    }
}
