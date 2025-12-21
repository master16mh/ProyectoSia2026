using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoSia2025.BD.Migrations
{
    /// <inheritdoc />
    public partial class DatosRelacionadosOk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmpresasId",
                table: "Obras",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EsMiEmpresa",
                table: "Empresas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Estado",
                table: "Empresas",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CargoContacto",
                table: "ContactoEmpresas",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "EsMiEmpresa",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Empresas");

            migrationBuilder.AlterColumn<string>(
                name: "CargoContacto",
                table: "ContactoEmpresas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
