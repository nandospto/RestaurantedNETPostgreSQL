using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class v116 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Endereco_Pedidos_PedidosID",
                table: "Endereco");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Pagamentos_PagamentosID",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_PagamentosID",
                table: "Pedidos");

            migrationBuilder.AddColumn<int>(
                name: "PedidosID",
                table: "Pagamentos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pagamentos_PedidosID",
                table: "Pagamentos",
                column: "PedidosID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Endereco_Pedidos_PedidosID",
                table: "Endereco",
                column: "PedidosID",
                principalTable: "Pedidos",
                principalColumn: "PedidosID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pagamentos_Pedidos_PedidosID",
                table: "Pagamentos",
                column: "PedidosID",
                principalTable: "Pedidos",
                principalColumn: "PedidosID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Endereco_Pedidos_PedidosID",
                table: "Endereco");

            migrationBuilder.DropForeignKey(
                name: "FK_Pagamentos_Pedidos_PedidosID",
                table: "Pagamentos");

            migrationBuilder.DropIndex(
                name: "IX_Pagamentos_PedidosID",
                table: "Pagamentos");

            migrationBuilder.DropColumn(
                name: "PedidosID",
                table: "Pagamentos");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_PagamentosID",
                table: "Pedidos",
                column: "PagamentosID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Endereco_Pedidos_PedidosID",
                table: "Endereco",
                column: "PedidosID",
                principalTable: "Pedidos",
                principalColumn: "PedidosID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Pagamentos_PagamentosID",
                table: "Pedidos",
                column: "PagamentosID",
                principalTable: "Pagamentos",
                principalColumn: "PagamentosID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
