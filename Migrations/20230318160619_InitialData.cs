using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projectEF.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Task",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "IdCategory", "Description", "Impact", "Name" },
                values: new object[] { new Guid("785f1edd-0a8f-4384-9f21-9d210692e685"), "", 30, "Actividades Grupales" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "IdCategory", "Description", "Impact", "Name" },
                values: new object[] { new Guid("bb400eef-eb06-4eed-90ac-cae351c8e3e5"), "", 20, "Actividades Pendientes" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "IdCategory", "Description", "Impact", "Name" },
                values: new object[] { new Guid("d8682463-0c22-4356-960c-2a25d3a961ac"), "", 50, "Actividades Personales" });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "IdTask", "CulminationDate", "DateCreate", "Description", "IdCategory", "Priority", "Title" },
                values: new object[] { new Guid("0c59ab0f-737b-4f62-8bc4-2eb725f3046d"), null, new DateTime(2023, 3, 18, 11, 6, 18, 945, DateTimeKind.Local).AddTicks(1966), "", new Guid("bb400eef-eb06-4eed-90ac-cae351c8e3e5"), 1, "Pago de Servicios Publicos" });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "IdTask", "CulminationDate", "DateCreate", "Description", "IdCategory", "Priority", "Title" },
                values: new object[] { new Guid("55d8ca55-2764-4ecf-b15b-e17ed218dd7e"), null, new DateTime(2023, 3, 18, 11, 6, 18, 945, DateTimeKind.Local).AddTicks(1979), "", new Guid("d8682463-0c22-4356-960c-2a25d3a961ac"), 0, "Terminar de ver pelicula en Netflix" });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "IdTask", "CulminationDate", "DateCreate", "Description", "IdCategory", "Priority", "Title" },
                values: new object[] { new Guid("c20458e1-beeb-42f5-83d1-b5e12bb487b3"), null, new DateTime(2023, 3, 18, 11, 6, 18, 945, DateTimeKind.Local).AddTicks(1982), "", new Guid("785f1edd-0a8f-4384-9f21-9d210692e685"), 2, "Pichanga del Viernes" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "IdTask",
                keyValue: new Guid("0c59ab0f-737b-4f62-8bc4-2eb725f3046d"));

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "IdTask",
                keyValue: new Guid("55d8ca55-2764-4ecf-b15b-e17ed218dd7e"));

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "IdTask",
                keyValue: new Guid("c20458e1-beeb-42f5-83d1-b5e12bb487b3"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "IdCategory",
                keyValue: new Guid("785f1edd-0a8f-4384-9f21-9d210692e685"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "IdCategory",
                keyValue: new Guid("bb400eef-eb06-4eed-90ac-cae351c8e3e5"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "IdCategory",
                keyValue: new Guid("d8682463-0c22-4356-960c-2a25d3a961ac"));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Task",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Category",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
