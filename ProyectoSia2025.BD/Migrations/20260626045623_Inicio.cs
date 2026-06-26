using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoSia2025.BD.Migrations
{
    /// <inheritdoc />
    public partial class Inicio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EsMiEmpresa = table.Column<bool>(type: "bit", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RazonSocial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CUIT = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.Id);
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
                name: "ContactoEmpresas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DNI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CargoContacto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactoEmpresas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactoEmpresas_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmpleadoPropio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DNI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DireccionHogarEmpleado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CargoEmpleado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpleadoPropio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpleadoPropio_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmpresasEmpresas",
                columns: table => new
                {
                    AsociadoConmigoId = table.Column<int>(type: "int", nullable: false),
                    EmpresasAsociadasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpresasEmpresas", x => new { x.AsociadoConmigoId, x.EmpresasAsociadasId });
                    table.ForeignKey(
                        name: "FK_EmpresasEmpresas_Empresas_AsociadoConmigoId",
                        column: x => x.AsociadoConmigoId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpresasEmpresas_Empresas_EmpresasAsociadasId",
                        column: x => x.EmpresasAsociadasId,
                        principalTable: "Empresas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Diseños",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ObraId = table.Column<int>(type: "int", nullable: false),
                    EmpleadoPropioId = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstadoPlano = table.Column<int>(type: "int", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false),
                    RutaArchivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreArchivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Extension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TamañoBytes = table.Column<long>(type: "bigint", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diseños", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Diseños_EmpleadoPropio_EmpleadoPropioId",
                        column: x => x.EmpleadoPropioId,
                        principalTable: "EmpleadoPropio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                });

            migrationBuilder.CreateTable(
                name: "Obras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    NombreObra = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ubicacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Presupuesto = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    FechaUltimaHabilitacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaVencimientoHabilitacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InformeHabilitanteId = table.Column<int>(type: "int", nullable: true),
                    MotivoNoHabilitacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstadoObra = table.Column<int>(type: "int", nullable: false),
                    EstadoHabilitacion = table.Column<int>(type: "int", nullable: false),
                    EmpresasId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Obras_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Obras_Empresas_EmpresasId",
                        column: x => x.EmpresasId,
                        principalTable: "Empresas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Obras_InformeInspecciones_InformeHabilitanteId",
                        column: x => x.InformeHabilitanteId,
                        principalTable: "InformeInspecciones",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Inspecciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ObraId = table.Column<int>(type: "int", nullable: false),
                    FechaProgramada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaRealizacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    estadoInspeccion = table.Column<int>(type: "int", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpleadoPropioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inspecciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inspecciones_EmpleadoPropio_EmpleadoPropioId",
                        column: x => x.EmpleadoPropioId,
                        principalTable: "EmpleadoPropio",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Inspecciones_Obras_ObraId",
                        column: x => x.ObraId,
                        principalTable: "Obras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ObrasContactos",
                columns: table => new
                {
                    ObraId = table.Column<int>(type: "int", nullable: false),
                    ContactoEmpresaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObrasContactos", x => new { x.ObraId, x.ContactoEmpresaId });
                    table.ForeignKey(
                        name: "FK_ObrasContactos_ContactoEmpresas_ContactoEmpresaId",
                        column: x => x.ContactoEmpresaId,
                        principalTable: "ContactoEmpresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ObrasContactos_Obras_ObraId",
                        column: x => x.ObraId,
                        principalTable: "Obras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ObrasEmpleados",
                columns: table => new
                {
                    ObraId = table.Column<int>(type: "int", nullable: false),
                    EmpleadoId = table.Column<int>(type: "int", nullable: false),
                    FechaAsignacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObrasEmpleados", x => new { x.ObraId, x.EmpleadoId });
                    table.ForeignKey(
                        name: "FK_ObrasEmpleados_EmpleadoPropio_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "EmpleadoPropio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ObrasEmpleados_Obras_ObraId",
                        column: x => x.ObraId,
                        principalTable: "Obras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateIndex(
                name: "Contacto_DNI",
                table: "ContactoEmpresas",
                column: "DNI",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContactoEmpresas_EmpresaId",
                table: "ContactoEmpresas",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Diseños_EmpleadoPropioId",
                table: "Diseños",
                column: "EmpleadoPropioId");

            migrationBuilder.CreateIndex(
                name: "IX_Diseños_ObraId",
                table: "Diseños",
                column: "ObraId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpleadoPropio_EmpresaId",
                table: "EmpleadoPropio",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "Empresa_CUIT",
                table: "Empresas",
                column: "CUIT",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmpresasEmpresas_EmpresasAsociadasId",
                table: "EmpresasEmpresas",
                column: "EmpresasAsociadasId");

            migrationBuilder.CreateIndex(
                name: "IX_InformeInspecciones_InspeccionId",
                table: "InformeInspecciones",
                column: "InspeccionId");

            migrationBuilder.CreateIndex(
                name: "IX_Inspecciones_EmpleadoPropioId",
                table: "Inspecciones",
                column: "EmpleadoPropioId");

            migrationBuilder.CreateIndex(
                name: "IX_Inspecciones_ObraId",
                table: "Inspecciones",
                column: "ObraId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Obras_EmpresaId",
                table: "Obras",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Obras_EmpresasId",
                table: "Obras",
                column: "EmpresasId");

            migrationBuilder.CreateIndex(
                name: "IX_Obras_InformeHabilitanteId",
                table: "Obras",
                column: "InformeHabilitanteId");

            migrationBuilder.CreateIndex(
                name: "IX_ObrasContactos_ContactoEmpresaId",
                table: "ObrasContactos",
                column: "ContactoEmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_ObrasEmpleados_EmpleadoId",
                table: "ObrasEmpleados",
                column: "EmpleadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Diseños_Obras_ObraId",
                table: "Diseños",
                column: "ObraId",
                principalTable: "Obras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InformeInspecciones_Inspecciones_InspeccionId",
                table: "InformeInspecciones",
                column: "InspeccionId",
                principalTable: "Inspecciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmpleadoPropio_Empresas_EmpresaId",
                table: "EmpleadoPropio");

            migrationBuilder.DropForeignKey(
                name: "FK_Obras_Empresas_EmpresaId",
                table: "Obras");

            migrationBuilder.DropForeignKey(
                name: "FK_Obras_Empresas_EmpresasId",
                table: "Obras");

            migrationBuilder.DropForeignKey(
                name: "FK_Inspecciones_EmpleadoPropio_EmpleadoPropioId",
                table: "Inspecciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Inspecciones_Obras_ObraId",
                table: "Inspecciones");

            migrationBuilder.DropTable(
                name: "Diseños");

            migrationBuilder.DropTable(
                name: "EmpresasEmpresas");

            migrationBuilder.DropTable(
                name: "InspeccionRequisitos");

            migrationBuilder.DropTable(
                name: "NoConformidades");

            migrationBuilder.DropTable(
                name: "ObrasContactos");

            migrationBuilder.DropTable(
                name: "ObrasEmpleados");

            migrationBuilder.DropTable(
                name: "RequisitoSeguridades");

            migrationBuilder.DropTable(
                name: "ContactoEmpresas");

            migrationBuilder.DropTable(
                name: "Empresas");

            migrationBuilder.DropTable(
                name: "EmpleadoPropio");

            migrationBuilder.DropTable(
                name: "Obras");

            migrationBuilder.DropTable(
                name: "InformeInspecciones");

            migrationBuilder.DropTable(
                name: "Inspecciones");
        }
    }
}
