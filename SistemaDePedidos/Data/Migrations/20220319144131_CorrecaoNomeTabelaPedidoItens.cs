using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaDePedidos.Data.Migrations
{
    public partial class CorrecaoNomeTabelaPedidoItens : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidoItem_Pedidos_PedidoId",
                table: "PedidoItem");

            migrationBuilder.DropForeignKey(
                name: "FK_PedidoItem_Produtos_ProdutoId",
                table: "PedidoItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PedidoItem",
                table: "PedidoItem");

            migrationBuilder.RenameTable(
                name: "PedidoItem",
                newName: "PedidoItens");

            migrationBuilder.RenameIndex(
                name: "IX_PedidoItem_ProdutoId",
                table: "PedidoItens",
                newName: "IX_PedidoItens_ProdutoId");

            migrationBuilder.RenameIndex(
                name: "IX_PedidoItem_PedidoId",
                table: "PedidoItens",
                newName: "IX_PedidoItens_PedidoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PedidoItens",
                table: "PedidoItens",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoItens_Pedidos_PedidoId",
                table: "PedidoItens",
                column: "PedidoId",
                principalTable: "Pedidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoItens_Produtos_ProdutoId",
                table: "PedidoItens",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidoItens_Pedidos_PedidoId",
                table: "PedidoItens");

            migrationBuilder.DropForeignKey(
                name: "FK_PedidoItens_Produtos_ProdutoId",
                table: "PedidoItens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PedidoItens",
                table: "PedidoItens");

            migrationBuilder.RenameTable(
                name: "PedidoItens",
                newName: "PedidoItem");

            migrationBuilder.RenameIndex(
                name: "IX_PedidoItens_ProdutoId",
                table: "PedidoItem",
                newName: "IX_PedidoItem_ProdutoId");

            migrationBuilder.RenameIndex(
                name: "IX_PedidoItens_PedidoId",
                table: "PedidoItem",
                newName: "IX_PedidoItem_PedidoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PedidoItem",
                table: "PedidoItem",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoItem_Pedidos_PedidoId",
                table: "PedidoItem",
                column: "PedidoId",
                principalTable: "Pedidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoItem_Produtos_ProdutoId",
                table: "PedidoItem",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
