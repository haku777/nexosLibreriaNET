using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Nexos_Libreria_API.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class migration_v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Autores",
                columns: new[] { "Id", "Ciudad_de_procedencia", "Correo_electronico", "Fecha_de_nacimiento", "Nombre_completo" },
                values: new object[,]
                {
                    { 1, "Japan", "jimmy1076667239@gmail.com", new DateTime(2023, 8, 19, 2, 59, 44, 966, DateTimeKind.Local).AddTicks(1491), "haku" },
                    { 2, "Japan", "v@v.com", new DateTime(2023, 8, 19, 2, 59, 44, 966, DateTimeKind.Local).AddTicks(1509), "Violet" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Autores",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Autores",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
