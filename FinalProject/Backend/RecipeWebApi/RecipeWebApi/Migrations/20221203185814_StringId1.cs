using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeWebApi.Migrations
{
    public partial class StringId1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comments_recipes_RecipeId1",
                table: "comments");

            migrationBuilder.DropForeignKey(
                name: "FK_comments_users_UserId",
                table: "comments");

            migrationBuilder.DropForeignKey(
                name: "FK_recipes_categories_CategoryId",
                table: "recipes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_recipes_CategoryId",
                table: "recipes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_comments",
                table: "comments");

            migrationBuilder.DropIndex(
                name: "IX_comments_RecipeId1",
                table: "comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_categories",
                table: "categories");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "users");

            migrationBuilder.DropColumn(
                name: "RecipeId1",
                table: "comments");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "categories");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "users",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CategoryId1",
                table: "recipes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "RecipeId",
                table: "comments",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "comments",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "UsersId",
                table: "comments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RecipesId",
                table: "comments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CategoryId",
                table: "categories",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_comments",
                table: "comments",
                columns: new[] { "UsersId", "RecipesId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_categories",
                table: "categories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_recipes_CategoryId1",
                table: "recipes",
                column: "CategoryId1");

            migrationBuilder.CreateIndex(
                name: "IX_comments_RecipeId",
                table: "comments",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_comments_UserId",
                table: "comments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_comments_recipes_RecipeId",
                table: "comments",
                column: "RecipeId",
                principalTable: "recipes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_comments_users_UserId",
                table: "comments",
                column: "UserId",
                principalTable: "users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_recipes_categories_CategoryId1",
                table: "recipes",
                column: "CategoryId1",
                principalTable: "categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comments_recipes_RecipeId",
                table: "comments");

            migrationBuilder.DropForeignKey(
                name: "FK_comments_users_UserId",
                table: "comments");

            migrationBuilder.DropForeignKey(
                name: "FK_recipes_categories_CategoryId1",
                table: "recipes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_recipes_CategoryId1",
                table: "recipes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_comments",
                table: "comments");

            migrationBuilder.DropIndex(
                name: "IX_comments_RecipeId",
                table: "comments");

            migrationBuilder.DropIndex(
                name: "IX_comments_UserId",
                table: "comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_categories",
                table: "categories");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "users");

            migrationBuilder.DropColumn(
                name: "CategoryId1",
                table: "recipes");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "comments");

            migrationBuilder.DropColumn(
                name: "RecipesId",
                table: "comments");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "categories");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "users",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "comments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RecipeId",
                table: "comments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RecipeId1",
                table: "comments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "categories",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_comments",
                table: "comments",
                columns: new[] { "UserId", "RecipeId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_categories",
                table: "categories",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_recipes_CategoryId",
                table: "recipes",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_comments_RecipeId1",
                table: "comments",
                column: "RecipeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_comments_recipes_RecipeId1",
                table: "comments",
                column: "RecipeId1",
                principalTable: "recipes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_comments_users_UserId",
                table: "comments",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_recipes_categories_CategoryId",
                table: "recipes",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
