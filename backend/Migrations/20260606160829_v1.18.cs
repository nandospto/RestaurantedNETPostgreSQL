using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class v118 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Clientes_ClientesID",
                table: "Pedidos");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Clientes_ClientesID",
                table: "Pedidos",
                column: "ClientesID",
                principalTable: "Clientes",
                principalColumn: "ClientesID",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Clientes_ClientesID",
                table: "Pedidos");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Clientes_ClientesID",
                table: "Pedidos",
                column: "ClientesID",
                principalTable: "Clientes",
                principalColumn: "ClientesID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
