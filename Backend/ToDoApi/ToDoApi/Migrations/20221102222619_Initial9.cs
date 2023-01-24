using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoApi.Migrations
{
    public partial class Initial9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "toDos",
                keyColumn: "Id",
                keyValue: 1,
                column: "DueDate",
                value: new DateTime(2022, 11, 3, 0, 26, 18, 940, DateTimeKind.Local).AddTicks(1981));

            migrationBuilder.UpdateData(
                table: "toDos",
                keyColumn: "Id",
                keyValue: 2,
                column: "DueDate",
                value: new DateTime(2022, 11, 3, 0, 26, 18, 940, DateTimeKind.Local).AddTicks(2017));

            migrationBuilder.CreateIndex(
                name: "IX_toDos_ToDoCategoryId",
                table: "toDos",
                column: "ToDoCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_toDos_toDoCategories_ToDoCategoryId",
                table: "toDos",
                column: "ToDoCategoryId",
                principalTable: "toDoCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_toDos_toDoCategories_ToDoCategoryId",
                table: "toDos");

            migrationBuilder.DropIndex(
                name: "IX_toDos_ToDoCategoryId",
                table: "toDos");

            migrationBuilder.UpdateData(
                table: "toDos",
                keyColumn: "Id",
                keyValue: 1,
                column: "DueDate",
                value: new DateTime(2022, 11, 3, 0, 15, 25, 95, DateTimeKind.Local).AddTicks(3094));

            migrationBuilder.UpdateData(
                table: "toDos",
                keyColumn: "Id",
                keyValue: 2,
                column: "DueDate",
                value: new DateTime(2022, 11, 3, 0, 15, 25, 95, DateTimeKind.Local).AddTicks(3126));
        }
    }
}
