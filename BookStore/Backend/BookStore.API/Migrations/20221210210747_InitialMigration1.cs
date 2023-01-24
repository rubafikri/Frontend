using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.API.Migrations
{
    public partial class InitialMigration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ContantUss",
                table: "ContantUss");

            migrationBuilder.RenameTable(
                name: "ContantUss",
                newName: "ContantUs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContantUs",
                table: "ContantUs",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ContantUs",
                table: "ContantUs");

            migrationBuilder.RenameTable(
                name: "ContantUs",
                newName: "ContantUss");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContantUss",
                table: "ContantUss",
                column: "Id");
        }
    }
}
