using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ofima_Management.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Empleados",
                columns: new[] { "Id", "Activo", "Cargo", "Departamento", "Direccion", "Email", "FechaContratacion", "Nombre", "Telefono" },
                values: new object[,]
                {
                    { 1, true, "Analista de Datos", "Inteligencia de Negocios", "Cra 12 #45-89", "ana.torres@ofima.com", new DateTime(2025, 2, 3, 15, 38, 24, 907, DateTimeKind.Local).AddTicks(5068), "Ana Torres", "3214567890" },
                    { 2, true, "Desarrollador .NET", "TI", "Calle 23 #12-45", "carlos.mendoza@ofima.com", new DateTime(2024, 7, 3, 15, 38, 24, 911, DateTimeKind.Local).AddTicks(2791), "Carlos Mendoza", "3123456789" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Empleados",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Empleados",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
