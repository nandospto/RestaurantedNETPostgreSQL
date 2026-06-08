using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class v115 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pagamentos_Pedidos_PedidosID",
                table: "Pagamentos");

            migrationBuilder.DropIndex(
                name: "IX_Pagamentos_PedidosID",
                table: "Pagamentos");

            migrationBuilder.DropColumn(
                name: "PedidosID",
                table: "Pagamentos");

            migrationBuilder.AddColumn<int>(
                name: "EnderencoID",
                table: "Pedidos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PagamentosID",
                table: "Pedidos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_PagamentosID",
                table: "Pedidos",
                column: "PagamentosID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Pagamentos_PagamentosID",
                table: "Pedidos",
                column: "PagamentosID",
                principalTable: "Pagamentos",
                principalColumn: "PagamentosID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Pagamentos_PagamentosID",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_PagamentosID",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "EnderencoID",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "PagamentosID",
                table: "Pedidos");

            migrationBuilder.AddColumn<int>(
                name: "PedidosID",
                table: "Pagamentos",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pagamentos_PedidosID",
                table: "Pagamentos",
                column: "PedidosID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pagamentos_Pedidos_PedidosID",
                table: "Pagamentos",
                column: "PedidosID",
                principalTable: "Pedidos",
                principalColumn: "PedidosID");
        }
    }
}
