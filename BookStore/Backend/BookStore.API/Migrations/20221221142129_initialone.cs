using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.API.Migrations
{
    public partial class initialone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "28e297fb-4e96-4313-9126-9124e818130e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a92c85f3-f631-4d9c-8239-cb802ea50578");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "646bbfcf-4ea2-4faf-ae24-275688f2907b", "ab7324a2-32f7-4a40-b763-2e49a2398023", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ef344f14-b899-4292-ba44-fd6fb1303697", "032ecfee-ddc2-425f-9cb5-46cf71bee1ea", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "28e297fb-4e96-4313-9126-9124e818130e", "96477035-f64f-4e02-8543-ad0985f25492", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a92c85f3-f631-4d9c-8239-cb802ea50578", "43790e6c-df5d-4d54-b892-8b56bf40edf1", "Admin", "ADMIN" });
        }
    }
}
