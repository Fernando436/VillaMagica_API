using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VillaMagica_API.Migrations
{
    /// <inheritdoc />
    public partial class AlimentarTablaVilla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Amenidad", "Detalle", "FechaActualizacion", "FechaCreacion", "ImagenUrl", "MetrosCuadrados", "Nombre", "Ocupantes", "Tarifa" },
                values: new object[,]
                {
                    { 1, "", "Fernando", new DateTime(2024, 2, 29, 16, 43, 43, 567, DateTimeKind.Local).AddTicks(4269), new DateTime(2024, 2, 29, 16, 43, 43, 567, DateTimeKind.Local).AddTicks(4257), "", 50, "Casitas", 5, 200.0 },
                    { 2, "", "Mont", new DateTime(2024, 2, 29, 16, 43, 43, 567, DateTimeKind.Local).AddTicks(4272), new DateTime(2024, 2, 29, 16, 43, 43, 567, DateTimeKind.Local).AddTicks(4272), "", 50, "navarro", 10, 1200.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
