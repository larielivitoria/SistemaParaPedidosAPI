using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PedidoAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoProdutoInPedido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProdutosInPedidos",
                table: "ProdutosInPedidos");

            migrationBuilder.DropIndex(
                name: "IX_ProdutosInPedidos_PedidoId",
                table: "ProdutosInPedidos");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ProdutosInPedidos");

            migrationBuilder.RenameColumn(
                name: "Quantidade",
                table: "ProdutosInPedidos",
                newName: "QuantidadeDeProduto");

            migrationBuilder.RenameColumn(
                name: "PrecoUnitario",
                table: "ProdutosInPedidos",
                newName: "ValorTotal");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProdutosInPedidos",
                table: "ProdutosInPedidos",
                columns: new[] { "PedidoId", "ProdutoId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProdutosInPedidos",
                table: "ProdutosInPedidos");

            migrationBuilder.RenameColumn(
                name: "ValorTotal",
                table: "ProdutosInPedidos",
                newName: "PrecoUnitario");

            migrationBuilder.RenameColumn(
                name: "QuantidadeDeProduto",
                table: "ProdutosInPedidos",
                newName: "Quantidade");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ProdutosInPedidos",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProdutosInPedidos",
                table: "ProdutosInPedidos",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutosInPedidos_PedidoId",
                table: "ProdutosInPedidos",
                column: "PedidoId");
        }
    }
}
