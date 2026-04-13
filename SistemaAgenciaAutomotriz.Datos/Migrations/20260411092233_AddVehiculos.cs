using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaAgenciaAutomotriz.Datos.Migrations
{
    /// <inheritdoc />
    public partial class AddVehiculos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "CostoSeguro",
                table: "Ventas",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Enganche",
                table: "Ventas",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Mensualidad",
                table: "Ventas",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MontoFinanciado",
                table: "Ventas",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "PlazoMeses",
                table: "Ventas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "RequiereSeguro",
                table: "Ventas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "TasaInteres",
                table: "Ventas",
                type: "decimal(5,2)",
                precision: 5,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "TipoPagoVEH",
                table: "Ventas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VehiculoId",
                table: "Ventas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactoEmergencia",
                table: "Clientes",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "INE",
                table: "Clientes",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Licencia",
                table: "Clientes",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TelefonoEmergencia",
                table: "Clientes",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Vehiculos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VIN = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Kilometraje = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Costo = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    Estatus = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ImagenPath = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Motor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Transmision = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Combustible = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    FechaAlta = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_VehiculoId",
                table: "Ventas",
                column: "VehiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_VIN",
                table: "Vehiculos",
                column: "VIN",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_Vehiculos_VehiculoId",
                table: "Ventas",
                column: "VehiculoId",
                principalTable: "Vehiculos",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_Vehiculos_VehiculoId",
                table: "Ventas");

            migrationBuilder.DropTable(
                name: "Vehiculos");

            migrationBuilder.DropIndex(
                name: "IX_Ventas_VehiculoId",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "CostoSeguro",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "Enganche",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "Mensualidad",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "MontoFinanciado",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "PlazoMeses",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "RequiereSeguro",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "TasaInteres",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "TipoPagoVEH",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "VehiculoId",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "ContactoEmergencia",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "INE",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Licencia",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "TelefonoEmergencia",
                table: "Clientes");
        }
    }
}
