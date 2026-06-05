using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class v09 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidosItensMenu_ItensMenu_ItemId",
                table: "PedidosItensMenu");

            migrationBuilder.DropForeignKey(
                name: "FK_PedidosItensMenu_Pedidos_PedidoId",
                table: "PedidosItensMenu");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "PedidosItensMenu",
                newName: "ItensMenuId");

            migrationBuilder.RenameIndex(
                name: "IX_PedidosItensMenu_ItemId",
                table: "PedidosItensMenu",
                newName: "IX_PedidosItensMenu_ItensMenuId");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "ItensMenu",
                newName: "ItemMenuId");

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    PedidoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "text", nullable: true),
                    Datapedido = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    ClienteId = table.Column<int>(type: "integer", nullable: false),
                    MesaId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.PedidoId);
                    table.ForeignKey(
                        name: "FK_Pedido_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedido_Mesa_MesaId",
                        column: x => x.MesaId,
                        principalTable: "Mesa",
                        principalColumn: "MesaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_ClienteId",
                table: "Pedido",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_MesaId",
                table: "Pedido",
                column: "MesaId");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidosItensMenu_ItensMenu_ItensMenuId",
                table: "PedidosItensMenu",
                column: "ItensMenuId",
                principalTable: "ItensMenu",
                principalColumn: "ItemMenuId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PedidosItensMenu_Pedido_PedidoId",
                table: "PedidosItensMenu",
                column: "PedidoId",
                principalTable: "Pedido",
                principalColumn: "PedidoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidosItensMenu_ItensMenu_ItensMenuId",
                table: "PedidosItensMenu");

            migrationBuilder.DropForeignKey(
                name: "FK_PedidosItensMenu_Pedido_PedidoId",
                table: "PedidosItensMenu");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.RenameColumn(
                name: "ItensMenuId",
                table: "PedidosItensMenu",
                newName: "ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_PedidosItensMenu_ItensMenuId",
                table: "PedidosItensMenu",
                newName: "IX_PedidosItensMenu_ItemId");

            migrationBuilder.RenameColumn(
                name: "ItemMenuId",
                table: "ItensMenu",
                newName: "ItemId");

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    PedidoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClienteId = table.Column<int>(type: "integer", nullable: false),
                    MesaId = table.Column<int>(type: "integer", nullable: false),
                    Datapedido = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Descricao = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.PedidoId);
                    table.ForeignKey(
                        name: "FK_Pedidos_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedidos_Mesa_MesaId",
                        column: x => x.MesaId,
                        principalTable: "Mesa",
                        principalColumn: "MesaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ClienteId",
                table: "Pedidos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_MesaId",
                table: "Pedidos",
                column: "MesaId");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidosItensMenu_ItensMenu_ItemId",
                table: "PedidosItensMenu",
                column: "ItemId",
                principalTable: "ItensMenu",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PedidosItensMenu_Pedidos_PedidoId",
                table: "PedidosItensMenu",
                column: "PedidoId",
                principalTable: "Pedidos",
                principalColumn: "PedidoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
