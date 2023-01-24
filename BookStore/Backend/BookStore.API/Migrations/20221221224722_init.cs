using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.API.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "646bbfcf-4ea2-4faf-ae24-275688f2907b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ef344f14-b899-4292-ba44-fd6fb1303697");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "99d94552-e1e3-4ab4-ba56-3740966f25b0", "25628e76-4d24-40f0-818a-4b52c16cf961", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b7a94154-bbf5-43f6-b7dc-86edd2060cb6", "1a670d9a-107b-469f-b870-441818103600", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "646bbfcf-4ea2-4faf-ae24-275688f2907b", "ab7324a2-32f7-4a40-b763-2e49a2398023", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ef344f14-b899-4292-ba44-fd6fb1303697", "032ecfee-ddc2-425f-9cb5-46cf71bee1ea", "Admin", "ADMIN" });
        }
    }
}
