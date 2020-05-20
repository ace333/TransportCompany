using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TransportCompany.Order.Infrastructure.Migrations
{
    public partial class OrderAggregate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Comments = table.Column<string>(maxLength: 255, nullable: true),
                    CustomerId = table.Column<int>(nullable: false),
                    DriverId = table.Column<int>(nullable: false),
                    PaymentAmount_Currency = table.Column<string>(maxLength: 64, nullable: true),
                    PaymentAmount_NetValue = table.Column<decimal>(nullable: true),
                    PaymentAmount_GrossValue = table.Column<decimal>(nullable: true),
                    PaymentAmount_Tax = table.Column<int>(nullable: true),
                    ExecutionCountry = table.Column<int>(nullable: false),
                    CustomersInvoice_Name = table.Column<string>(maxLength: 255, nullable: true),
                    CustomersInvoice_CreatedDate = table.Column<DateTime>(nullable: true),
                    CustomersInvoice_Content = table.Column<byte[]>(nullable: true),
                    DriversInvoice_Name = table.Column<string>(maxLength: 255, nullable: true),
                    DriversInvoice_CreatedDate = table.Column<DateTime>(nullable: true),
                    DriversInvoice_Content = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order");
        }
    }
}
