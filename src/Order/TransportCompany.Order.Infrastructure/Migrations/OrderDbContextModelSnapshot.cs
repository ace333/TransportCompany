﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TransportCompany.Order.Infrastructure;
using TransportCompany.Order.Infrastructure.Persistence;

namespace TransportCompany.Order.Infrastructure.Migrations
{
    [DbContext(typeof(OrderDbContext))]
    partial class OrderDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TransportCompany.Order.Domain.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comments")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("DriverId")
                        .HasColumnType("int");

                    b.Property<int>("ExecutionCountry")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("TransportCompany.Order.Domain.Entities.Order", b =>
                {
                    b.OwnsOne("TransportCompany.Order.Domain.ValueObjects.PaymentAmount", "PaymentAmount", b1 =>
                        {
                            b1.Property<int>("OrderId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<decimal>("GrossValue")
                                .HasColumnType("decimal(18,2)");

                            b1.Property<decimal>("NetValue")
                                .HasColumnType("decimal(18,2)");

                            b1.Property<int>("Tax")
                                .HasColumnType("int");

                            b1.HasKey("OrderId");

                            b1.ToTable("Order");

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });

                    b.OwnsOne("TransportCompany.Shared.Domain.ValueObjects.Invoice", "CustomersInvoice", b1 =>
                        {
                            b1.Property<int>("OrderId")
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

                            b1.HasKey("OrderId");

                            b1.ToTable("Order");

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });

                    b.OwnsOne("TransportCompany.Shared.Domain.ValueObjects.Invoice", "DriversInvoice", b1 =>
                        {
                            b1.Property<int>("OrderId")
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

                            b1.HasKey("OrderId");

                            b1.ToTable("Order");

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
