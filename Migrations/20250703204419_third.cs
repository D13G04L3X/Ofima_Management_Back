using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ofima_Management.Migrations
{
    /// <inheritdoc />
    public partial class third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Empleados",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaContratacion",
                value: new DateTime(2023, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Empleados",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaContratacion",
                value: new DateTime(2023, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Empleados",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaContratacion",
                value: new DateTime(2025, 2, 3, 15, 38, 24, 907, DateTimeKind.Local).AddTicks(5068));

            migrationBuilder.UpdateData(
                table: "Empleados",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaContratacion",
                value: new DateTime(2024, 7, 3, 15, 38, 24, 911, DateTimeKind.Local).AddTicks(2791));
        }
    }
}
