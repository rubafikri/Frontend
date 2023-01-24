using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.API.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Addresses_AddressId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "99509ac3-669e-45ab-9f45-eec7e02a6841");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "28e297fb-4e96-4313-9126-9124e818130e", "96477035-f64f-4e02-8543-ad0985f25492", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a92c85f3-f631-4d9c-8239-cb802ea50578", "43790e6c-df5d-4d54-b892-8b56bf40edf1", "Admin", "ADMIN" });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Addresses_AddressId",
                table: "AspNetUsers",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Addresses_AddressId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "28e297fb-4e96-4313-9126-9124e818130e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a92c85f3-f631-4d9c-8239-cb802ea50578");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "AspNetUsers",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AddressId", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "99509ac3-669e-45ab-9f45-eec7e02a6841", 0, null, "d1d7be23-cb4a-490d-b14f-8e148e092988", null, false, "Ruba", null, "Fikri", false, null, null, null, null, null, false, "aefc77f2-f8a7-4c05-8c93-62af9bb49182", false, null });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Addresses_AddressId",
                table: "AspNetUsers",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id");
        }
    }
}
