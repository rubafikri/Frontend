using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.API.Migrations
{
    public partial class initl1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2b89f4a3-db77-4d6a-a546-232f26a0df16");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4e981d42-06ca-4d37-86da-863ad853ae9e");

            migrationBuilder.AddColumn<int>(
                name: "IsSold",
                table: "Sales",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "SoldDate",
                table: "Sales",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4e61ab56-dd01-4b89-b02f-0526146ce68e", "b894fd26-5e56-4feb-a13f-48219d41c376", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "81dd66bf-e9d8-428a-a72d-7c9e079ca4ac", "e311b376-9840-45a1-889b-b8e786cbeca5", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4e61ab56-dd01-4b89-b02f-0526146ce68e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "81dd66bf-e9d8-428a-a72d-7c9e079ca4ac");

            migrationBuilder.DropColumn(
                name: "IsSold",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "SoldDate",
                table: "Sales");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2b89f4a3-db77-4d6a-a546-232f26a0df16", "6fbfb33b-d26d-42a9-9566-90cce26148ed", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4e981d42-06ca-4d37-86da-863ad853ae9e", "181434a3-3575-4108-b306-066dd2f25a9d", "Admin", "ADMIN" });
        }
    }
}
