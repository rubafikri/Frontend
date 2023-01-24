using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeWebApi.Migrations
{
    public partial class StringId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_recipes_categories_CategoryId1",
                table: "recipes");

            migrationBuilder.DropIndex(
                name: "IX_recipes_CategoryId1",
                table: "recipes");

            migrationBuilder.DropColumn(
                name: "CategoryId1",
                table: "recipes");

            migrationBuilder.AlterColumn<string>(
                name: "CategoryId",
                table: "recipes",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_recipes_CategoryId",
                table: "recipes",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_recipes_categories_CategoryId",
                table: "recipes",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_recipes_categories_CategoryId",
                table: "recipes");

            migrationBuilder.DropIndex(
                name: "IX_recipes_CategoryId",
                table: "recipes");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "recipes",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "CategoryId1",
                table: "recipes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_recipes_CategoryId1",
                table: "recipes",
                column: "CategoryId1");

            migrationBuilder.AddForeignKey(
                name: "FK_recipes_categories_CategoryId1",
                table: "recipes",
                column: "CategoryId1",
                principalTable: "categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
