using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TransportCompany.Driver.Infrastructure.Migrations
{
    public partial class DriverAggregate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Driver",
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
                    SystemInfo_UpdatedDate = table.Column<DateTime>(nullable: true),
                    DriversLicense_Number = table.Column<string>(maxLength: 64, nullable: true),
                    DriversLicense_DateOfIssue = table.Column<DateTime>(nullable: true),
                    DriversLicense_ExpiryDate = table.Column<DateTime>(nullable: true),
                    Car_Model = table.Column<string>(maxLength: 64, nullable: true),
                    Car_RegistrationPlateNumber = table.Column<string>(maxLength: 64, nullable: true),
                    CompanyDetails_CompanyName = table.Column<string>(maxLength: 255, nullable: true),
                    CompanyDetails_OwnerName = table.Column<string>(maxLength: 255, nullable: true),
                    CompanyDetails_BankDetails_AccountNumber = table.Column<string>(maxLength: 64, nullable: true),
                    CompanyDetails_BankDetails_BankName = table.Column<string>(maxLength: 64, nullable: true),
                    CompanyDetails_Address_Street = table.Column<string>(maxLength: 64, nullable: true),
                    CompanyDetails_Address_HouseNumber = table.Column<string>(maxLength: 64, nullable: true),
                    CompanyDetails_Address_ZipCode = table.Column<string>(maxLength: 64, nullable: true),
                    CompanyDetails_Address_City = table.Column<string>(maxLength: 64, nullable: true),
                    CompanyDetails_Address_State = table.Column<string>(maxLength: 64, nullable: true),
                    CompanyDetails_Address_Country = table.Column<string>(maxLength: 64, nullable: true),
                    CompanyDetails_TaxIdentificationNumber = table.Column<int>(nullable: true),
                    CompanyDetails_NationalEconomyRegisterNumber = table.Column<int>(nullable: true),
                    Priority = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Driver", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ride",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    Income_Currency = table.Column<string>(maxLength: 64, nullable: true),
                    Income_Amount = table.Column<decimal>(nullable: true),
                    CustomerDetails_Name = table.Column<string>(maxLength: 64, nullable: true),
                    CustomerDetails_Grade = table.Column<decimal>(nullable: true),
                    Invoice_Name = table.Column<string>(maxLength: 255, nullable: true),
                    Invoice_CreatedDate = table.Column<DateTime>(nullable: true),
                    Invoice_Content = table.Column<byte[]>(nullable: true),
                    DriverId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ride", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ride_Driver_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Driver",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DestinationPoint",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Address_Street = table.Column<string>(maxLength: 64, nullable: true),
                    Address_HouseNumber = table.Column<string>(maxLength: 64, nullable: true),
                    Address_ZipCode = table.Column<string>(maxLength: 64, nullable: true),
                    Address_City = table.Column<string>(maxLength: 64, nullable: true),
                    Address_State = table.Column<string>(maxLength: 64, nullable: true),
                    Address_Country = table.Column<string>(maxLength: 64, nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    RideId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DestinationPoint", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DestinationPoint_Ride_RideId",
                        column: x => x.RideId,
                        principalTable: "Ride",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DestinationPoint_RideId",
                table: "DestinationPoint",
                column: "RideId");

            migrationBuilder.CreateIndex(
                name: "IX_Ride_DriverId",
                table: "Ride",
                column: "DriverId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DestinationPoint");

            migrationBuilder.DropTable(
                name: "Ride");

            migrationBuilder.DropTable(
                name: "Driver");
        }
    }
}
