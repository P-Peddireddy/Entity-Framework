using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Example1.Migrations
{
    public partial class InitDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Price = table.Column<long>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => new { x.Name, x.Price });
                });

            migrationBuilder.CreateTable(
                name: "SaleItems",
                columns: table => new
                {
                    Price = table.Column<long>(type: "INTEGER", nullable: false),
                    SaleName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: false),
                    ProductName = table.Column<string>(type: "TEXT", nullable: true),
                    ProductPrice = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleItems", x => new { x.SaleName, x.Price });
                    table.ForeignKey(
                        name: "FK_SaleItems_Products_ProductName_ProductPrice",
                        columns: x => new { x.ProductName, x.ProductPrice },
                        principalTable: "Products",
                        principalColumns: new[] { "Name", "Price" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SaleItems_ProductName_ProductPrice",
                table: "SaleItems",
                columns: new[] { "ProductName", "ProductPrice" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SaleItems");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
