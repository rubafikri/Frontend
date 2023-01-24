using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoApi.Migrations
{
    public partial class Initial12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_toDos_toDoCategories_toDoCategoryId",
                table: "toDos");

            migrationBuilder.DropIndex(
                name: "IX_toDos_toDoCategoryId",
                table: "toDos");

            migrationBuilder.DropColumn(
                name: "toDoCategoryId",
                table: "toDos");

            migrationBuilder.InsertData(
                table: "toDoCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Complete" },
                    { 2, "Imprtant" }
                });

            migrationBuilder.InsertData(
                table: "toDos",
                columns: new[] { "Id", "CatergoryId", "Description", "DueDate", "IsCompleted", "Task" },
                values: new object[,]
                {
                    { 1, 1, "Task 1 HAs completed", new DateTime(2022, 11, 2, 23, 58, 55, 821, DateTimeKind.Local).AddTicks(2717), true, "Task 1" },
                    { 2, 2, "Task 2 HAs completed", new DateTime(2022, 11, 2, 23, 58, 55, 821, DateTimeKind.Local).AddTicks(2748), false, "Task 2" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "toDoCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "toDoCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "toDos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "toDos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AddColumn<int>(
                name: "toDoCategoryId",
                table: "toDos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_toDos_toDoCategoryId",
                table: "toDos",
                column: "toDoCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_toDos_toDoCategories_toDoCategoryId",
                table: "toDos",
                column: "toDoCategoryId",
                principalTable: "toDoCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
