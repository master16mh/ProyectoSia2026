using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoSia2025.BD.Migrations
{
    /// <inheritdoc />
    public partial class Requisitos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Obras",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "EstadoHabilitacion",
                table: "Obras",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaUltimaHabilitacion",
                table: "Obras",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaVencimientoHabilitacion",
                table: "Obras",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InformeHabilitanteId",
                table: "Obras",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MotivoNoHabilitacion",
                table: "Obras",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "InformeInspecciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InspeccionId = table.Column<int>(type: "int", nullable: false),
                    Resultado = table.Column<int>(type: "int", nullable: false),
                    FechaEmision = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Conclusiones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RutaPdfInforme = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InformeInspecciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InformeInspecciones_Inspecciones_InspeccionId",
                        column: x => x.InspeccionId,
                        principalTable: "Inspecciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Obras_InformeHabilitanteId",
                table: "Obras",
                column: "InformeHabilitanteId");

            migrationBuilder.CreateIndex(
                name: "IX_InformeInspecciones_InspeccionId",
                table: "InformeInspecciones",
                column: "InspeccionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Obras_InformeInspecciones_InformeHabilitanteId",
                table: "Obras",
                column: "InformeHabilitanteId",
                principalTable: "InformeInspecciones",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Obras_InformeInspecciones_InformeHabilitanteId",
                table: "Obras");

            migrationBuilder.DropTable(
                name: "InformeInspecciones");

            migrationBuilder.DropIndex(
                name: "IX_Obras_InformeHabilitanteId",
                table: "Obras");

            migrationBuilder.DropColumn(
                name: "EstadoHabilitacion",
                table: "Obras");

            migrationBuilder.DropColumn(
                name: "FechaUltimaHabilitacion",
                table: "Obras");

            migrationBuilder.DropColumn(
                name: "FechaVencimientoHabilitacion",
                table: "Obras");

            migrationBuilder.DropColumn(
                name: "InformeHabilitanteId",
                table: "Obras");

            migrationBuilder.DropColumn(
                name: "MotivoNoHabilitacion",
                table: "Obras");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Obras",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
