using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nexos_Libreria_API.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class migration_v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libros_Autores_AutorId",
                table: "Libros");

            migrationBuilder.RenameColumn(
                name: "AutorId",
                table: "Libros",
                newName: "Id_Autor");

            migrationBuilder.RenameIndex(
                name: "IX_Libros_AutorId",
                table: "Libros",
                newName: "IX_Libros_Id_Autor");

            migrationBuilder.RenameColumn(
                name: "Fecha_de_nacimiento",
                table: "Autores",
                newName: "Fecha_nacimiento");

            migrationBuilder.RenameColumn(
                name: "Ciudad_de_procedencia",
                table: "Autores",
                newName: "Ciudad_procedencia");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Libros_Autores_Id_Autor",
                table: "Libros",
                column: "Id_Autor",
                principalTable: "Autores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libros_Autores_Id_Autor",
                table: "Libros");

            migrationBuilder.RenameColumn(
                name: "Id_Autor",
                table: "Libros",
                newName: "AutorId");

            migrationBuilder.RenameIndex(
                name: "IX_Libros_Id_Autor",
                table: "Libros",
                newName: "IX_Libros_AutorId");

            migrationBuilder.RenameColumn(
                name: "Fecha_nacimiento",
                table: "Autores",
                newName: "Fecha_de_nacimiento");

            migrationBuilder.RenameColumn(
                name: "Ciudad_procedencia",
                table: "Autores",
                newName: "Ciudad_de_procedencia");

            migrationBuilder.UpdateData(
                table: "Autores",
                keyColumn: "Id",
                keyValue: 1,
                column: "Fecha_de_nacimiento",
                value: new DateTime(2023, 8, 19, 2, 59, 44, 966, DateTimeKind.Local).AddTicks(1491));

            migrationBuilder.UpdateData(
                table: "Autores",
                keyColumn: "Id",
                keyValue: 2,
                column: "Fecha_de_nacimiento",
                value: new DateTime(2023, 8, 19, 2, 59, 44, 966, DateTimeKind.Local).AddTicks(1509));

            migrationBuilder.AddForeignKey(
                name: "FK_Libros_Autores_AutorId",
                table: "Libros",
                column: "AutorId",
                principalTable: "Autores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
