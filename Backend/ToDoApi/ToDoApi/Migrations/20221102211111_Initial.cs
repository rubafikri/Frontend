using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoApi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "toDoCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_toDoCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "toDos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Task = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    CatergoryId = table.Column<int>(type: "int", nullable: false),
                    toDoCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_toDos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_toDos_toDoCategories_toDoCategoryId",
                        column: x => x.toDoCategoryId,
                        principalTable: "toDoCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_toDos_toDoCategoryId",
                table: "toDos",
                column: "toDoCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "toDos");

            migrationBuilder.DropTable(
                name: "toDoCategories");
        }
    }
}
