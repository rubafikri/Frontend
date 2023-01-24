using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortofiloProject.Migrations
{
    public partial class UpdateNullableImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Budy",
                table: "projects",
                newName: "Body");

            migrationBuilder.AlterColumn<string>(
                name: "ImageName",
                table: "projects",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Body",
                table: "projects",
                newName: "Budy");

            migrationBuilder.AlterColumn<string>(
                name: "ImageName",
                table: "projects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
