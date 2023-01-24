using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoApi.Migrations
{
    public partial class Initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CatergoryId",
                table: "toDos",
                newName: "ToDoCategoryId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ToDoCategoryId",
                table: "toDos",
                newName: "CatergoryId");

            migrationBuilder.UpdateData(
                table: "toDos",
                keyColumn: "Id",
                keyValue: 1,
                column: "DueDate",
                value: new DateTime(2022, 11, 2, 23, 58, 55, 821, DateTimeKind.Local).AddTicks(2717));

            migrationBuilder.UpdateData(
                table: "toDos",
                keyColumn: "Id",
                keyValue: 2,
                column: "DueDate",
                value: new DateTime(2022, 11, 2, 23, 58, 55, 821, DateTimeKind.Local).AddTicks(2748));
        }
    }
}
