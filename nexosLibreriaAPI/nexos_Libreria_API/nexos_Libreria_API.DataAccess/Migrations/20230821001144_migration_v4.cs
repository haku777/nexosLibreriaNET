using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nexos_Libreria_API.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class migration_v4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Autores",
                keyColumn: "Id",
                keyValue: 1,
                column: "Fecha_nacimiento",
                value: new DateTime(2023, 8, 20, 19, 11, 44, 272, DateTimeKind.Local).AddTicks(9950));

            migrationBuilder.UpdateData(
                table: "Autores",
                keyColumn: "Id",
                keyValue: 2,
                column: "Fecha_nacimiento",
                value: new DateTime(2023, 8, 20, 19, 11, 44, 272, DateTimeKind.Local).AddTicks(9963));

            migrationBuilder.InsertData(
                table: "Libros",
                columns: new[] { "Id", "Fecha", "Genero", "Id_Autor", "Numero_de_paginas", "Titulo" },
                values: new object[] { 1, new DateTime(2023, 8, 20, 19, 11, 44, 273, DateTimeKind.Local).AddTicks(131), "Terror", 1, 7, "ApiBook" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Autores",
                keyColumn: "Id",
                keyValue: 1,
                column: "Fecha_nacimiento",
                value: new DateTime(2023, 8, 20, 19, 5, 9, 243, DateTimeKind.Local).AddTicks(5810));

            migrationBuilder.UpdateData(
                table: "Autores",
                keyColumn: "Id",
                keyValue: 2,
                column: "Fecha_nacimiento",
                value: new DateTime(2023, 8, 20, 19, 5, 9, 243, DateTimeKind.Local).AddTicks(5823));
        }
    }
}
