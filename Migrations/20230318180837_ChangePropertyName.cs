using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projectEF.Migrations
{
    public partial class ChangePropertyName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateCreate",
                table: "Task",
                newName: "CreationDate");

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "IdTask",
                keyValue: new Guid("0c59ab0f-737b-4f62-8bc4-2eb725f3046d"),
                column: "CreationDate",
                value: new DateTime(2023, 3, 18, 13, 8, 37, 588, DateTimeKind.Local).AddTicks(4686));

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "IdTask",
                keyValue: new Guid("55d8ca55-2764-4ecf-b15b-e17ed218dd7e"),
                column: "CreationDate",
                value: new DateTime(2023, 3, 18, 13, 8, 37, 588, DateTimeKind.Local).AddTicks(4697));

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "IdTask",
                keyValue: new Guid("c20458e1-beeb-42f5-83d1-b5e12bb487b3"),
                column: "CreationDate",
                value: new DateTime(2023, 3, 18, 13, 8, 37, 588, DateTimeKind.Local).AddTicks(4700));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "Task",
                newName: "DateCreate");

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "IdTask",
                keyValue: new Guid("0c59ab0f-737b-4f62-8bc4-2eb725f3046d"),
                column: "DateCreate",
                value: new DateTime(2023, 3, 18, 11, 6, 18, 945, DateTimeKind.Local).AddTicks(1966));

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "IdTask",
                keyValue: new Guid("55d8ca55-2764-4ecf-b15b-e17ed218dd7e"),
                column: "DateCreate",
                value: new DateTime(2023, 3, 18, 11, 6, 18, 945, DateTimeKind.Local).AddTicks(1979));

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "IdTask",
                keyValue: new Guid("c20458e1-beeb-42f5-83d1-b5e12bb487b3"),
                column: "DateCreate",
                value: new DateTime(2023, 3, 18, 11, 6, 18, 945, DateTimeKind.Local).AddTicks(1982));
        }
    }
}
