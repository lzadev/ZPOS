using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZPOS.UI.Migrations
{
    public partial class RemoveRequiredAttrFromEmailInClient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Clients",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 4, 20, 9, 49, 18, 924, DateTimeKind.Local).AddTicks(9895));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2021, 4, 20, 9, 49, 18, 925, DateTimeKind.Local).AddTicks(8126));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2021, 4, 20, 9, 49, 18, 925, DateTimeKind.Local).AddTicks(8155));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Clients",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 4, 19, 17, 53, 9, 818, DateTimeKind.Local).AddTicks(9342));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2021, 4, 19, 17, 53, 9, 819, DateTimeKind.Local).AddTicks(8598));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2021, 4, 19, 17, 53, 9, 819, DateTimeKind.Local).AddTicks(8634));
        }
    }
}
