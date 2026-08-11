using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoSia2025.BD.Migrations
{
    /// <inheritdoc />
    public partial class Formateo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Obras_Empresas_EmpresasId",
                table: "Obras");

            migrationBuilder.DropTable(
                name: "EmpresasEmpresas");

            migrationBuilder.DropIndex(
                name: "IX_Obras_EmpresasId",
                table: "Obras");

            migrationBuilder.DropColumn(
                name: "EmpresasId",
                table: "Obras");

            migrationBuilder.DropColumn(
                name: "Resultado",
                table: "InformeInspecciones");

            migrationBuilder.DropColumn(
                name: "EstadoPlano",
                table: "Diseños");

            migrationBuilder.DropColumn(
                name: "Apellido",
                table: "ContactoEmpresas");

            migrationBuilder.DropColumn(
                name: "CargoContacto",
                table: "ContactoEmpresas");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "ContactoEmpresas",
                newName: "Rol");

            migrationBuilder.AlterColumn<string>(
                name: "estadoInspeccion",
                table: "Inspecciones",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ResultadoInspección",
                table: "InformeInspecciones",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "Estado",
                table: "Empresas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CargoEmpleado",
                table: "EmpleadoPropio",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DNI",
                table: "ContactoEmpresas",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResultadoInspección",
                table: "InformeInspecciones");

            migrationBuilder.RenameColumn(
                name: "Rol",
                table: "ContactoEmpresas",
                newName: "Email");

            migrationBuilder.AddColumn<int>(
                name: "EmpresasId",
                table: "Obras",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "estadoInspeccion",
                table: "Inspecciones",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "Resultado",
                table: "InformeInspecciones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Estado",
                table: "Empresas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CargoEmpleado",
                table: "EmpleadoPropio",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "EstadoPlano",
                table: "Diseños",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "DNI",
                table: "ContactoEmpresas",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Apellido",
                table: "ContactoEmpresas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CargoContacto",
                table: "ContactoEmpresas",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_Obras_EmpresasId",
                table: "Obras",
                column: "EmpresasId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpresasEmpresas_EmpresasAsociadasId",
                table: "EmpresasEmpresas",
                column: "EmpresasAsociadasId");

            migrationBuilder.AddForeignKey(
                name: "FK_Obras_Empresas_EmpresasId",
                table: "Obras",
                column: "EmpresasId",
                principalTable: "Empresas",
                principalColumn: "Id");
        }
    }
}
