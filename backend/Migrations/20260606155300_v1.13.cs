using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class v113 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Endereco_Pedidos_PedidosID",
                table: "Endereco");

            migrationBuilder.DropForeignKey(
                name: "FK_Pagamentos_Pedidos_PedidosID",
                table: "Pagamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Clientes_ClientesID",
                table: "Pedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Clientes_ClientesID1",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_ClientesID1",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "ClientesID1",
                table: "Pedidos");

            migrationBuilder.AddForeignKey(
                name: "FK_Endereco_Pedidos_PedidosID",
                table: "Endereco",
                column: "PedidosID",
                principalTable: "Pedidos",
                principalColumn: "PedidosID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pagamentos_Pedidos_PedidosID",
                table: "Pagamentos",
                column: "PedidosID",
                principalTable: "Pedidos",
                principalColumn: "PedidosID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Clientes_ClientesID",
                table: "Pedidos",
                column: "ClientesID",
                principalTable: "Clientes",
                principalColumn: "ClientesID",
                onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Clientes_ClientesID",
                table: "Pedidos");

            migrationBuilder.AddColumn<int>(
                name: "ClientesID1",
                table: "Pedidos",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ClientesID1",
                table: "Pedidos",
                column: "ClientesID1");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Clientes_ClientesID",
                table: "Pedidos",
                column: "ClientesID",
                principalTable: "Clientes",
                principalColumn: "ClientesID",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Clientes_ClientesID1",
                table: "Pedidos",
                column: "ClientesID1",
                principalTable: "Clientes",
                principalColumn: "ClientesID");
        }
    }
}
