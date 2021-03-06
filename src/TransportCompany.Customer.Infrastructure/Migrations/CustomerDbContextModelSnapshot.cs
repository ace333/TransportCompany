﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TransportCompany.Customer.Domain.Enums;
using TransportCompany.Customer.Infrastructure.Persistence;

namespace TransportCompany.Customer.Infrastructure.Migrations
{
    [DbContext(typeof(CustomerDbContext))]
    partial class CustomerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TransportCompany.Customer.Domain.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("TransportCompany.Customer.Domain.Entities.FavoriteAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("FavoriteAddress");
                });

            modelBuilder.Entity("TransportCompany.Customer.Domain.Entities.PaymentMethods.PaymentMethod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<bool>("IsPreffered")
                        .HasColumnType("bit");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("PaymentMethod");

                    b.HasDiscriminator<int>("Type");
                });

            modelBuilder.Entity("TransportCompany.Customer.Domain.Entities.Ride", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("DriverId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FinishedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Ride");
                });

            modelBuilder.Entity("TransportCompany.Customer.Domain.Entities.Route", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<int?>("PreviousRouteId")
                        .HasColumnType("int");

                    b.Property<int?>("RideId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PreviousRouteId");

                    b.HasIndex("RideId");

                    b.ToTable("Route");
                });

            modelBuilder.Entity("TransportCompany.Customer.Domain.Entities.PaymentMethods.DebitOrCreditCard", b =>
                {
                    b.HasBaseType("TransportCompany.Customer.Domain.Entities.PaymentMethods.PaymentMethod");

                    b.Property<long>("CardNumber")
                        .HasColumnType("bigint");

                    b.Property<int>("Country")
                        .HasColumnType("int");

                    b.Property<int>("CvvCode")
                        .HasColumnType("int");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("datetime2");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("TransportCompany.Customer.Domain.Entities.PaymentMethods.PayPal", b =>
                {
                    b.HasBaseType("TransportCompany.Customer.Domain.Entities.PaymentMethods.PaymentMethod");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.Property<bool>("IsAlwaysLoggedIn")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.HasDiscriminator().HasValue(2);
                });

            modelBuilder.Entity("TransportCompany.Customer.Domain.Entities.Customer", b =>
                {
                    b.OwnsOne("TransportCompany.Customer.Domain.ValueObjects.PersonalInfo", "PersonalInfo", b1 =>
                        {
                            b1.Property<int>("CustomerId")
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

                            b1.HasKey("CustomerId");

                            b1.ToTable("Customer");

                            b1.WithOwner()
                                .HasForeignKey("CustomerId");
                        });

                    b.OwnsOne("TransportCompany.Customer.Domain.ValueObjects.SystemInfo", "SystemInfo", b1 =>
                        {
                            b1.Property<int>("CustomerId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<decimal>("Grade")
                                .HasColumnType("decimal(18, 2)");

                            b1.Property<DateTime?>("UpdatedDate")
                                .ValueGeneratedOnUpdate()
                                .HasColumnType("datetime2");

                            b1.HasKey("CustomerId");

                            b1.ToTable("Customer");

                            b1.WithOwner()
                                .HasForeignKey("CustomerId");
                        });
                });

            modelBuilder.Entity("TransportCompany.Customer.Domain.Entities.FavoriteAddress", b =>
                {
                    b.HasOne("TransportCompany.Customer.Domain.Entities.Customer", "Customer")
                        .WithMany("FavoriteAddresses")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsOne("TransportCompany.Shared.Domain.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<int>("FavoriteAddressId")
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

                            b1.HasKey("FavoriteAddressId");

                            b1.ToTable("FavoriteAddress");

                            b1.WithOwner()
                                .HasForeignKey("FavoriteAddressId");
                        });
                });

            modelBuilder.Entity("TransportCompany.Customer.Domain.Entities.PaymentMethods.PaymentMethod", b =>
                {
                    b.HasOne("TransportCompany.Customer.Domain.Entities.Customer", "Customer")
                        .WithMany("PaymentMethods")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TransportCompany.Customer.Domain.Entities.Ride", b =>
                {
                    b.HasOne("TransportCompany.Customer.Domain.Entities.Customer", "Customer")
                        .WithMany("Rides")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsOne("TransportCompany.Shared.Domain.ValueObjects.DriverDetails", "DriverDetails", b1 =>
                        {
                            b1.Property<int>("RideId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("CarModel")
                                .HasColumnType("nvarchar(64)")
                                .HasMaxLength(64);

                            b1.Property<string>("CarRegistrationPlateNumber")
                                .HasColumnType("nvarchar(64)")
                                .HasMaxLength(64);

                            b1.Property<decimal>("Grade")
                                .HasColumnType("decimal(18,2)");

                            b1.Property<string>("Name")
                                .HasColumnType("nvarchar(64)")
                                .HasMaxLength(64);

                            b1.Property<string>("PhoneNumber")
                                .HasColumnType("nvarchar(64)")
                                .HasMaxLength(64);

                            b1.Property<byte[]>("Photo")
                                .HasColumnType("varbinary(max)");

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

                    b.OwnsOne("TransportCompany.Shared.Domain.ValueObjects.Money", "Price", b1 =>
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

            modelBuilder.Entity("TransportCompany.Customer.Domain.Entities.Route", b =>
                {
                    b.HasOne("TransportCompany.Customer.Domain.Entities.Route", "PreviousRoute")
                        .WithMany()
                        .HasForeignKey("PreviousRouteId");

                    b.HasOne("TransportCompany.Customer.Domain.Entities.Ride", "Ride")
                        .WithMany("Routes")
                        .HasForeignKey("RideId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsOne("TransportCompany.Shared.Domain.ValueObjects.Address", "DestinationPoint", b1 =>
                        {
                            b1.Property<int>("RouteId")
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

                            b1.HasKey("RouteId");

                            b1.ToTable("Route");

                            b1.WithOwner()
                                .HasForeignKey("RouteId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
