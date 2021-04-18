using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZPOS.UI.Migrations
{
    public partial class ModificandoRleacionEntreCategoriaProducto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_BrandID",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryID",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 4, 18, 17, 57, 37, 225, DateTimeKind.Local).AddTicks(8540));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2021, 4, 18, 17, 57, 37, 226, DateTimeKind.Local).AddTicks(6814));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2021, 4, 18, 17, 57, 37, 226, DateTimeKind.Local).AddTicks(6839));

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brands_BrandID",
                table: "Products",
                column: "BrandID",
                principalTable: "Brands",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryID",
                table: "Products",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_BrandID",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryID",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 4, 16, 10, 33, 54, 219, DateTimeKind.Local).AddTicks(1289));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2021, 4, 16, 10, 33, 54, 219, DateTimeKind.Local).AddTicks(9267));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2021, 4, 16, 10, 33, 54, 219, DateTimeKind.Local).AddTicks(9292));

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brands_BrandID",
                table: "Products",
                column: "BrandID",
                principalTable: "Brands",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryID",
                table: "Products",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
