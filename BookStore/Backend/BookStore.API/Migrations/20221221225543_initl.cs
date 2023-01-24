using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.API.Migrations
{
    public partial class initl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99d94552-e1e3-4ab4-ba56-3740966f25b0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7a94154-bbf5-43f6-b7dc-86edd2060cb6");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2b89f4a3-db77-4d6a-a546-232f26a0df16", "6fbfb33b-d26d-42a9-9566-90cce26148ed", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4e981d42-06ca-4d37-86da-863ad853ae9e", "181434a3-3575-4108-b306-066dd2f25a9d", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2b89f4a3-db77-4d6a-a546-232f26a0df16");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4e981d42-06ca-4d37-86da-863ad853ae9e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "99d94552-e1e3-4ab4-ba56-3740966f25b0", "25628e76-4d24-40f0-818a-4b52c16cf961", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b7a94154-bbf5-43f6-b7dc-86edd2060cb6", "1a670d9a-107b-469f-b870-441818103600", "Admin", "ADMIN" });
        }
    }
}
