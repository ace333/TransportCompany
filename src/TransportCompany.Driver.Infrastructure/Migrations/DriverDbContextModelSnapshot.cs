﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TransportCompany.Driver.Infrastructure.Persistence;

namespace TransportCompany.Driver.Infrastructure.Migrations
{
    [DbContext(typeof(DriverDbContext))]
    partial class DriverDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TransportCompany.Driver.Domain.Entities.DestinationPoint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<int?>("RideId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("RideId");

                    b.ToTable("DestinationPoint");
                });

            modelBuilder.Entity("TransportCompany.Driver.Domain.Entities.Driver", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Driver");
                });

            modelBuilder.Entity("TransportCompany.Driver.Domain.Entities.Ride", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int?>("DriverId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DriverId");

                    b.ToTable("Ride");
                });

            modelBuilder.Entity("TransportCompany.Driver.Domain.Entities.RideRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("RideRequest");
                });

            modelBuilder.Entity("TransportCompany.Driver.Domain.Entities.DestinationPoint", b =>
                {
                    b.HasOne("TransportCompany.Driver.Domain.Entities.Ride", "Ride")
                        .WithMany("Stops")
                        .HasForeignKey("RideId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsOne("TransportCompany.Shared.Domain.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<int>("DestinationPointId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("nvarchar(64)")
                                .HasMaxLength(64);

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasColumnType("nvarchar(64)")
                                .HasMaxLength(64);

                            b1.Property<string>("HouseNumber")
                                .HasColumnType("nvarchar(64)")
                                .HasMaxLength(64);

                            b1.Property<string>("State")
                                .HasColumnType("nvarchar(64)")
                                .HasMaxLength(64);

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("nvarchar(64)")
                                .HasMaxLength(64);

                            b1.Property<string>("ZipCode")
                                .HasColumnType("nvarchar(64)")
                                .HasMaxLength(64);

                            b1.HasKey("DestinationPointId");

                            b1.ToTable("DestinationPoint");

                            b1.WithOwner()
                                .HasForeignKey("DestinationPointId");
                        });
                });

            modelBuilder.Entity("TransportCompany.Driver.Domain.Entities.Driver", b =>
                {
                    b.OwnsOne("TransportCompany.Driver.Domain.ValueObjects.Car", "Car", b1 =>
                        {
                            b1.Property<int>("DriverId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Model")
                                .IsRequired()
                                .HasColumnType("nvarchar(64)")
                                .HasMaxLength(64);

                            b1.Property<string>("RegistrationPlateNumber")
                                .IsRequired()
                                .HasColumnType("nvarchar(64)")
                                .HasMaxLength(64);

                            b1.HasKey("DriverId");

                            b1.ToTable("Driver");

                            b1.WithOwner()
                                .HasForeignKey("DriverId");
                        });

                    b.OwnsOne("TransportCompany.Driver.Domain.ValueObjects.CompanyDetails", "CompanyDetails", b1 =>
                        {
                            b1.Property<int>("DriverId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("CompanyName")
                                .IsRequired()
                                .HasColumnType("nvarchar(255)")
                                .HasMaxLength(255);

                            b1.Property<int>("NationalEconomyRegisterNumber")
                                .HasColumnType("int");

                            b1.Property<string>("OwnerName")
                                .IsRequired()
                                .HasColumnType("nvarchar(255)")
                                .HasMaxLength(255);

                            b1.Property<int>("TaxIdentificationNumber")
                                .HasColumnType("int");

                            b1.HasKey("DriverId");

                            b1.ToTable("Driver");

                            b1.WithOwner()
                                .HasForeignKey("DriverId");

                            b1.OwnsOne("TransportCompany.Driver.Domain.ValueObjects.BankDetails", "BankDetails", b2 =>
                                {
                                    b2.Property<int>("CompanyDetailsDriverId")
                                        .ValueGeneratedOnAdd()
                                        .HasColumnType("int")
                                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                                    b2.Property<string>("AccountNumber")
                                        .IsRequired()
                                        .HasColumnType("nvarchar(64)")
                                        .HasMaxLength(64);

                                    b2.Property<string>("BankName")
                                        .IsRequired()
                                        .HasColumnType("nvarchar(64)")
                                        .HasMaxLength(64);

                                    b2.HasKey("CompanyDetailsDriverId");

                                    b2.ToTable("Driver");

                                    b2.WithOwner()
                                        .HasForeignKey("CompanyDetailsDriverId");
                                });

                            b1.OwnsOne("TransportCompany.Shared.Domain.ValueObjects.Address", "Address", b2 =>
                                {
                                    b2.Property<int>("CompanyDetailsDriverId")
                                        .ValueGeneratedOnAdd()
                                        .HasColumnType("int")
                                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                                    b2.Property<string>("City")
                                        .IsRequired()
                                        .HasColumnType("nvarchar(64)")
                                        .HasMaxLength(64);

                                    b2.Property<string>("Country")
                                        .IsRequired()
                                        .HasColumnType("nvarchar(64)")
                                        .HasMaxLength(64);

                                    b2.Property<string>("HouseNumber")
                                        .HasColumnType("nvarchar(64)")
                                        .HasMaxLength(64);

                                    b2.Property<string>("State")
                                        .HasColumnType("nvarchar(64)")
                                        .HasMaxLength(64);

                                    b2.Property<string>("Street")
                                        .IsRequired()
                                        .HasColumnType("nvarchar(64)")
                                        .HasMaxLength(64);

                                    b2.Property<string>("ZipCode")
                                        .HasColumnType("nvarchar(64)")
                                        .HasMaxLength(64);

                                    b2.HasKey("CompanyDetailsDriverId");

                                    b2.ToTable("Driver");

                                    b2.WithOwner()
                                        .HasForeignKey("CompanyDetailsDriverId");
                                });
                        });

                    b.OwnsOne("TransportCompany.Driver.Domain.ValueObjects.DriversLicense", "DriversLicense", b1 =>
                        {
                            b1.Property<int>("DriverId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<DateTime>("DateOfIssue")
                                .HasColumnType("datetime2");

                            b1.Property<DateTime>("ExpiryDate")
                                .HasColumnType("datetime2");

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasColumnType("nvarchar(64)")
                                .HasMaxLength(64);

                            b1.HasKey("DriverId");

                            b1.ToTable("Driver");

                            b1.WithOwner()
                                .HasForeignKey("DriverId");
                        });

                    b.OwnsOne("TransportCompany.Driver.Domain.ValueObjects.PersonalInfo", "PersonalInfo", b1 =>
                        {
                            b1.Property<int>("DriverId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Email")
                                .HasColumnType("nvarchar(64)")
                                .HasMaxLength(64);

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("nvarchar(64)")
                                .HasMaxLength(64);

                            b1.Property<int>("Nationality")
                                .HasColumnType("int");

                            b1.Property<string>("PhoneNumber")
                                .HasColumnType("nvarchar(64)")
                                .HasMaxLength(64);

                            b1.Property<byte[]>("Photo")
                                .HasColumnType("varbinary(max)");

                            b1.Property<string>("Surname")
                                .IsRequired()
                                .HasColumnType("nvarchar(64)")
                                .HasMaxLength(64);

                            b1.HasKey("DriverId");

                            b1.ToTable("Driver");

                            b1.WithOwner()
                                .HasForeignKey("DriverId");
                        });

                    b.OwnsOne("TransportCompany.Driver.Domain.ValueObjects.SystemInfo", "SystemInfo", b1 =>
                        {
                            b1.Property<int>("DriverId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<decimal>("Grade")
                                .HasColumnType("decimal(18, 2)");

                            b1.Property<DateTime?>("UpdatedDate")
                                .ValueGeneratedOnUpdate()
                                .HasColumnType("datetime2");

                            b1.HasKey("DriverId");

                            b1.ToTable("Driver");

                            b1.WithOwner()
                                .HasForeignKey("DriverId");
                        });
                });

            modelBuilder.Entity("TransportCompany.Driver.Domain.Entities.Ride", b =>
                {
                    b.HasOne("TransportCompany.Driver.Domain.Entities.Driver", "Driver")
                        .WithMany("Rides")
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsOne("TransportCompany.Shared.Domain.ValueObjects.CustomerDetails", "CustomerDetails", b1 =>
                        {
                            b1.Property<int>("RideId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Email")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<decimal>("Grade")
                                .HasColumnType("decimal(18, 2)");

                            b1.Property<string>("Name")
                                .HasColumnType("nvarchar(64)")
                                .HasMaxLength(64);

                            b1.Property<string>("PhoneNumber")
                                .HasColumnType("nvarchar(64)")
                                .HasMaxLength(64);

                            b1.Property<string>("Surname")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("RideId");

                            b1.ToTable("Ride");

                            b1.WithOwner()
                                .HasForeignKey("RideId");
                        });

                    b.OwnsOne("TransportCompany.Shared.Domain.ValueObjects.Invoice", "Invoice", b1 =>
                        {
                            b1.Property<int>("RideId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<byte[]>("Content")
                                .HasColumnType("varbinary(max)");

                            b1.Property<DateTime>("CreatedDate")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("datetime2");

                            b1.Property<string>("Name")
                                .HasColumnType("nvarchar(255)")
                                .HasMaxLength(255);

                            b1.HasKey("RideId");

                            b1.ToTable("Ride");

                            b1.WithOwner()
                                .HasForeignKey("RideId");
                        });

                    b.OwnsOne("TransportCompany.Shared.Domain.ValueObjects.Money", "Income", b1 =>
                        {
                            b1.Property<int>("RideId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<decimal>("Amount")
                                .HasColumnType("decimal(18, 2)");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasColumnType("nvarchar(64)")
                                .HasMaxLength(64);

                            b1.HasKey("RideId");

                            b1.ToTable("Ride");

                            b1.WithOwner()
                                .HasForeignKey("RideId");
                        });
                });

            modelBuilder.Entity("TransportCompany.Driver.Domain.Entities.RideRequest", b =>
                {
                    b.OwnsOne("TransportCompany.Shared.Domain.ValueObjects.Address", "DestinationPoint", b1 =>
                        {
                            b1.Property<int>("RideRequestId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("nvarchar(64)")
                                .HasMaxLength(64);

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasColumnType("nvarchar(64)")
                                .HasMaxLength(64);

                            b1.Property<string>("HouseNumber")
                                .HasColumnType("nvarchar(64)")
                                .HasMaxLength(64);

                            b1.Property<string>("State")
                                .HasColumnType("nvarchar(64)")
                                .HasMaxLength(64);

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("nvarchar(64)")
                                .HasMaxLength(64);

                            b1.Property<string>("ZipCode")
                                .HasColumnType("nvarchar(64)")
                                .HasMaxLength(64);

                            b1.HasKey("RideRequestId");

                            b1.ToTable("RideRequest");

                            b1.WithOwner()
                                .HasForeignKey("RideRequestId");
                        });

                    b.OwnsOne("TransportCompany.Shared.Domain.ValueObjects.Address", "StartPoint", b1 =>
                        {
                            b1.Property<int>("RideRequestId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("nvarchar(64)")
                                .HasMaxLength(64);

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasColumnType("nvarchar(64)")
                                .HasMaxLength(64);

                            b1.Property<string>("HouseNumber")
                                .HasColumnType("nvarchar(64)")
                                .HasMaxLength(64);

                            b1.Property<string>("State")
                                .HasColumnType("nvarchar(64)")
                                .HasMaxLength(64);

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("nvarchar(64)")
                                .HasMaxLength(64);

                            b1.Property<string>("ZipCode")
                                .HasColumnType("nvarchar(64)")
                                .HasMaxLength(64);

                            b1.HasKey("RideRequestId");

                            b1.ToTable("RideRequest");

                            b1.WithOwner()
                                .HasForeignKey("RideRequestId");
                        });

                    b.OwnsOne("TransportCompany.Shared.Domain.ValueObjects.CustomerDetails", "CustomerDetails", b1 =>
                        {
                            b1.Property<int>("RideRequestId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Email")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<decimal>("Grade")
                                .HasColumnType("decimal(18, 2)");

                            b1.Property<string>("Name")
                                .HasColumnType("nvarchar(64)")
                                .HasMaxLength(64);

                            b1.Property<string>("PhoneNumber")
                                .HasColumnType("nvarchar(64)")
                                .HasMaxLength(64);

                            b1.Property<string>("Surname")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("RideRequestId");

                            b1.ToTable("RideRequest");

                            b1.WithOwner()
                                .HasForeignKey("RideRequestId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
