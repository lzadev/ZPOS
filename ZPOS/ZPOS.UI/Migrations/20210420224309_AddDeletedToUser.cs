using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZPOS.UI.Migrations
{
    public partial class AddDeletedToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "AspNetUsers");

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
                columns: new[] { "ID", "BrandID", "BuyPrice", "CategoryID", "Code", "CreationDate", "Description", "SellPrice", "Status" },
                values: new object[] { 2, 1, 850.50m, 1, "002238", new DateTime(2021, 4, 20, 15, 37, 34, 310, DateTimeKind.Local).AddTicks(7988), "Chancletas sport size 10", 1600.38m, false });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "BrandID", "BuyPrice", "CategoryID", "Code", "CreationDate", "Description", "SellPrice", "Status" },
                values: new object[] { 3, 4, 850.50m, 2, "002256", new DateTime(2021, 4, 20, 15, 37, 34, 310, DateTimeKind.Local).AddTicks(8015), "T shirt crema ", 1600.38m, false });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "BrandID", "BuyPrice", "CategoryID", "Code", "CreationDate", "Description", "SellPrice", "Status" },
                values: new object[] { 1, 1, 400.50m, 3, "002236", new DateTime(2021, 4, 20, 15, 37, 34, 309, DateTimeKind.Local).AddTicks(9611), "Meidas unisex x3", 600m, false });
        }
    }
}
