using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TransportCompany.Customer.Infrastructure.Migrations
{
    public partial class CustomerAggregate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    PersonalInfo_Name = table.Column<string>(maxLength: 64, nullable: true),
                    PersonalInfo_Surname = table.Column<string>(maxLength: 64, nullable: true),
                    PersonalInfo_Photo = table.Column<byte[]>(nullable: true),
                    PersonalInfo_PhoneNumber = table.Column<string>(maxLength: 64, nullable: true),
                    PersonalInfo_Email = table.Column<string>(maxLength: 64, nullable: true),
                    PersonalInfo_Nationality = table.Column<int>(nullable: true),
                    SystemInfo_Grade = table.Column<decimal>(nullable: true),
                    SystemInfo_UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FavoriteAddress",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 64, nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Address_Street = table.Column<string>(maxLength: 64, nullable: true),
                    Address_HouseNumber = table.Column<string>(maxLength: 64, nullable: true),
                    Address_ZipCode = table.Column<string>(maxLength: 64, nullable: true),
                    Address_City = table.Column<string>(maxLength: 64, nullable: true),
                    Address_State = table.Column<string>(maxLength: 64, nullable: true),
                    Address_Country = table.Column<string>(maxLength: 64, nullable: true),
                    CustomerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FavoriteAddress_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethod",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: true),
                    CardNumber = table.Column<int>(nullable: true),
                    ExpiryDate = table.Column<DateTime>(nullable: true),
                    CvvCode = table.Column<int>(nullable: true),
                    Country = table.Column<int>(nullable: true),
                    Email = table.Column<string>(maxLength: 64, nullable: true),
                    Password = table.Column<string>(maxLength: 64, nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 64, nullable: true),
                    IsAlwaysLoggedIn = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethod", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentMethod_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ride",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    FinishedDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    Price_Currency = table.Column<string>(maxLength: 64, nullable: true),
                    Price_Amount = table.Column<decimal>(nullable: true),
                    DriverDetails_Name = table.Column<string>(maxLength: 64, nullable: true),
                    DriverDetails_Grade = table.Column<decimal>(nullable: true),
                    DriverDetails_Photo = table.Column<byte[]>(nullable: true),
                    DriverDetails_CarModel = table.Column<string>(maxLength: 64, nullable: true),
                    Invoice_Name = table.Column<string>(maxLength: 255, nullable: true),
                    Invoice_CreatedDate = table.Column<DateTime>(nullable: true),
                    Invoice_Content = table.Column<byte[]>(nullable: true),
                    CustomerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ride", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ride_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Route",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    StartPoint_Street = table.Column<string>(maxLength: 64, nullable: true),
                    StartPoint_HouseNumber = table.Column<string>(maxLength: 64, nullable: true),
                    StartPoint_ZipCode = table.Column<string>(maxLength: 64, nullable: true),
                    StartPoint_City = table.Column<string>(maxLength: 64, nullable: true),
                    StartPoint_State = table.Column<string>(maxLength: 64, nullable: true),
                    StartPoint_Country = table.Column<string>(maxLength: 64, nullable: true),
                    Destination_Street = table.Column<string>(maxLength: 64, nullable: true),
                    Destination_HouseNumber = table.Column<string>(maxLength: 64, nullable: true),
                    Destination_ZipCode = table.Column<string>(maxLength: 64, nullable: true),
                    Destination_City = table.Column<string>(maxLength: 64, nullable: true),
                    Destination_State = table.Column<string>(maxLength: 64, nullable: true),
                    Destination_Country = table.Column<string>(maxLength: 64, nullable: true),
                    RideId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Route", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Route_Ride_RideId",
                        column: x => x.RideId,
                        principalTable: "Ride",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteAddress_CustomerId",
                table: "FavoriteAddress",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMethod_CustomerId",
                table: "PaymentMethod",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Ride_CustomerId",
                table: "Ride",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Route_RideId",
                table: "Route",
                column: "RideId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavoriteAddress");

            migrationBuilder.DropTable(
                name: "PaymentMethod");

            migrationBuilder.DropTable(
                name: "Route");

            migrationBuilder.DropTable(
                name: "Ride");

            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
