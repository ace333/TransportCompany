using Microsoft.EntityFrameworkCore.Migrations;

namespace TransportCompany.Customer.Infrastructure.Migrations
{
    public partial class PaymentMethodUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price_Amount",
                table: "Ride",
                type: "decimal(18, 2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsPreffered",
                table: "PaymentMethod",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPreffered",
                table: "PaymentMethod");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price_Amount",
                table: "Ride",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 2)",
                oldNullable: true);
        }
    }
}
