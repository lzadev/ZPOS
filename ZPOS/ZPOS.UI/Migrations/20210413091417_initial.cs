using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZPOS.UI.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: false),
                    CategoryID = table.Column<int>(nullable: false),
                    BrandID = table.Column<int>(nullable: false),
                    BuyPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SellPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandID",
                        column: x => x.BrandID,
                        principalTable: "Brands",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Nike" },
                    { 2, "Addidas" },
                    { 3, "Champion" },
                    { 4, "Generico" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Calzados" },
                    { 2, "Ropa" },
                    { 3, "Accesorios" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "BrandID", "BuyPrice", "CategoryID", "Code", "CreationDate", "Description", "SellPrice" },
                values: new object[] { 2, 1, 850.50m, 1, "002238", new DateTime(2021, 4, 13, 5, 14, 16, 835, DateTimeKind.Local).AddTicks(9203), "Chancletas sport size 10", 1600.38m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "BrandID", "BuyPrice", "CategoryID", "Code", "CreationDate", "Description", "SellPrice" },
                values: new object[] { 3, 4, 850.50m, 2, "002256", new DateTime(2021, 4, 13, 5, 14, 16, 835, DateTimeKind.Local).AddTicks(9231), "T shirt crema ", 1600.38m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "BrandID", "BuyPrice", "CategoryID", "Code", "CreationDate", "Description", "SellPrice" },
                values: new object[] { 1, 1, 400.50m, 3, "002236", new DateTime(2021, 4, 13, 5, 14, 16, 834, DateTimeKind.Local).AddTicks(8282), "Meidas unisex x3", 600m });

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandID",
                table: "Products",
                column: "BrandID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryID",
                table: "Products",
                column: "CategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
