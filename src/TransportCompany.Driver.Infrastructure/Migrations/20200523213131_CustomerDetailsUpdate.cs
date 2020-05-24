using Microsoft.EntityFrameworkCore.Migrations;

namespace TransportCompany.Driver.Infrastructure.Migrations
{
    public partial class CustomerDetailsUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomerDetails_Email",
                table: "RideRequest",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerDetails_Surname",
                table: "RideRequest",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerDetails_Email",
                table: "Ride",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerDetails_Surname",
                table: "Ride",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerDetails_Email",
                table: "RideRequest");

            migrationBuilder.DropColumn(
                name: "CustomerDetails_Surname",
                table: "RideRequest");

            migrationBuilder.DropColumn(
                name: "CustomerDetails_Email",
                table: "Ride");

            migrationBuilder.DropColumn(
                name: "CustomerDetails_Surname",
                table: "Ride");
        }
    }
}
