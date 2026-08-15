using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoSia2025.BD.Migrations
{
    /// <inheritdoc />
    public partial class TelefonoEmpresa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Telefono",
                table: "Empresas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "Empresas");
        }
    }
}
