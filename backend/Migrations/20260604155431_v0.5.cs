using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class v05 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Clientes_ClientesId",
                table: "Pedidos");

            migrationBuilder.RenameColumn(
                name: "ClientesId",
                table: "Pedidos",
                newName: "ClientesClienteId");

            migrationBuilder.RenameIndex(
                name: "IX_Pedidos_ClientesId",
                table: "Pedidos",
                newName: "IX_Pedidos_ClientesClienteId");

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Pedidos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Clientes_ClientesClienteId",
                table: "Pedidos",
                column: "ClientesClienteId",
                principalTable: "Clientes",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Clientes_ClientesClienteId",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Pedidos");

            migrationBuilder.RenameColumn(
                name: "ClientesClienteId",
                table: "Pedidos",
                newName: "ClientesId");

            migrationBuilder.RenameIndex(
                name: "IX_Pedidos_ClientesClienteId",
                table: "Pedidos",
                newName: "IX_Pedidos_ClientesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Clientes_ClientesId",
                table: "Pedidos",
                column: "ClientesId",
                principalTable: "Clientes",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
