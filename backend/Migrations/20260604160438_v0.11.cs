using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class v011 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Cliente_ClienteId",
                table: "Pedido");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Mesa_MesaId",
                table: "Pedido");

            migrationBuilder.DropForeignKey(
                name: "FK_PedidosItensMenu_ItensMenu_ItensMenuId",
                table: "PedidosItensMenu");

            migrationBuilder.DropForeignKey(
                name: "FK_PedidosItensMenu_Pedido_PedidoId",
                table: "PedidosItensMenu");

            migrationBuilder.RenameColumn(
                name: "ItensMenuId",
                table: "PedidosItensMenu",
                newName: "ItensMenuID");

            migrationBuilder.RenameColumn(
                name: "PedidoId",
                table: "PedidosItensMenu",
                newName: "PedidoID");

            migrationBuilder.RenameIndex(
                name: "IX_PedidosItensMenu_ItensMenuId",
                table: "PedidosItensMenu",
                newName: "IX_PedidosItensMenu_ItensMenuID");

            migrationBuilder.RenameColumn(
                name: "MesaId",
                table: "Pedido",
                newName: "MesaID");

            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "Pedido",
                newName: "ClienteID");

            migrationBuilder.RenameIndex(
                name: "IX_Pedido_MesaId",
                table: "Pedido",
                newName: "IX_Pedido_MesaID");

            migrationBuilder.RenameIndex(
                name: "IX_Pedido_ClienteId",
                table: "Pedido",
                newName: "IX_Pedido_ClienteID");

            migrationBuilder.RenameColumn(
                name: "MesaId",
                table: "Mesa",
                newName: "MesaID");

            migrationBuilder.RenameColumn(
                name: "ItensMenuId",
                table: "ItensMenu",
                newName: "ItensMenuID");

            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "Cliente",
                newName: "ClienteID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Cliente_ClienteID",
                table: "Pedido",
                column: "ClienteID",
                principalTable: "Cliente",
                principalColumn: "ClienteID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Mesa_MesaID",
                table: "Pedido",
                column: "MesaID",
                principalTable: "Mesa",
                principalColumn: "MesaID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PedidosItensMenu_ItensMenu_ItensMenuID",
                table: "PedidosItensMenu",
                column: "ItensMenuID",
                principalTable: "ItensMenu",
                principalColumn: "ItensMenuID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PedidosItensMenu_Pedido_PedidoID",
                table: "PedidosItensMenu",
                column: "PedidoID",
                principalTable: "Pedido",
                principalColumn: "PedidoID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Cliente_ClienteID",
                table: "Pedido");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Mesa_MesaID",
                table: "Pedido");

            migrationBuilder.DropForeignKey(
                name: "FK_PedidosItensMenu_ItensMenu_ItensMenuID",
                table: "PedidosItensMenu");

            migrationBuilder.DropForeignKey(
                name: "FK_PedidosItensMenu_Pedido_PedidoID",
                table: "PedidosItensMenu");

            migrationBuilder.RenameColumn(
                name: "ItensMenuID",
                table: "PedidosItensMenu",
                newName: "ItensMenuId");

            migrationBuilder.RenameColumn(
                name: "PedidoID",
                table: "PedidosItensMenu",
                newName: "PedidoId");

            migrationBuilder.RenameIndex(
                name: "IX_PedidosItensMenu_ItensMenuID",
                table: "PedidosItensMenu",
                newName: "IX_PedidosItensMenu_ItensMenuId");

            migrationBuilder.RenameColumn(
                name: "MesaID",
                table: "Pedido",
                newName: "MesaId");

            migrationBuilder.RenameColumn(
                name: "ClienteID",
                table: "Pedido",
                newName: "ClienteId");

            migrationBuilder.RenameIndex(
                name: "IX_Pedido_MesaID",
                table: "Pedido",
                newName: "IX_Pedido_MesaId");

            migrationBuilder.RenameIndex(
                name: "IX_Pedido_ClienteID",
                table: "Pedido",
                newName: "IX_Pedido_ClienteId");

            migrationBuilder.RenameColumn(
                name: "MesaID",
                table: "Mesa",
                newName: "MesaId");

            migrationBuilder.RenameColumn(
                name: "ItensMenuID",
                table: "ItensMenu",
                newName: "ItensMenuId");

            migrationBuilder.RenameColumn(
                name: "ClienteID",
                table: "Cliente",
                newName: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Cliente_ClienteId",
                table: "Pedido",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Mesa_MesaId",
                table: "Pedido",
                column: "MesaId",
                principalTable: "Mesa",
                principalColumn: "MesaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PedidosItensMenu_ItensMenu_ItensMenuId",
                table: "PedidosItensMenu",
                column: "ItensMenuId",
                principalTable: "ItensMenu",
                principalColumn: "ItensMenuId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PedidosItensMenu_Pedido_PedidoId",
                table: "PedidosItensMenu",
                column: "PedidoId",
                principalTable: "Pedido",
                principalColumn: "PedidoID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
