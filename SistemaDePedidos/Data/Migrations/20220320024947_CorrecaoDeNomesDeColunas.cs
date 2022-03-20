using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaDePedidos.Data.Migrations
{
    public partial class CorrecaoDeNomesDeColunas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InciadoEm",
                table: "Pedidos",
                newName: "IniciadoEm");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Clientes",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IniciadoEm",
                table: "Pedidos",
                newName: "InciadoEm");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Clientes",
                newName: "ID");
        }
    }
}
