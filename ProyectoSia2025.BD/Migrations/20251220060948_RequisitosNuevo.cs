using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoSia2025.BD.Migrations
{
    /// <inheritdoc />
    public partial class RequisitosNuevo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NoConformidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InspeccionId = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaLimiteCorreccion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Corregida = table.Column<bool>(type: "bit", nullable: false),
                    FechaCorreccion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoConformidades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NoConformidades_Inspecciones_InspeccionId",
                        column: x => x.InspeccionId,
                        principalTable: "Inspecciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequisitoSeguridades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EsObligatorio = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequisitoSeguridades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InspeccionRequisitos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InspeccionId = table.Column<int>(type: "int", nullable: false),
                    RequisitoSeguridadId = table.Column<int>(type: "int", nullable: false),
                    Cumple = table.Column<bool>(type: "bit", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspeccionRequisitos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspeccionRequisitos_Inspecciones_InspeccionId",
                        column: x => x.InspeccionId,
                        principalTable: "Inspecciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InspeccionRequisitos_RequisitoSeguridades_RequisitoSeguridadId",
                        column: x => x.RequisitoSeguridadId,
                        principalTable: "RequisitoSeguridades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InspeccionRequisitos_InspeccionId",
                table: "InspeccionRequisitos",
                column: "InspeccionId");

            migrationBuilder.CreateIndex(
                name: "IX_InspeccionRequisitos_RequisitoSeguridadId",
                table: "InspeccionRequisitos",
                column: "RequisitoSeguridadId");

            migrationBuilder.CreateIndex(
                name: "IX_NoConformidades_InspeccionId",
                table: "NoConformidades",
                column: "InspeccionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InspeccionRequisitos");

            migrationBuilder.DropTable(
                name: "NoConformidades");

            migrationBuilder.DropTable(
                name: "RequisitoSeguridades");
        }
    }
}
