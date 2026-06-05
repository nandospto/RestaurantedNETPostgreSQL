using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class v010 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PedidoId",
                table: "Pedido",
                newName: "PedidoID");

            migrationBuilder.RenameColumn(
                name: "ItemMenuId",
                table: "ItensMenu",
                newName: "ItensMenuId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PedidoID",
                table: "Pedido",
                newName: "PedidoId");

            migrationBuilder.RenameColumn(
                name: "ItensMenuId",
                table: "ItensMenu",
                newName: "ItemMenuId");
        }
    }
}
