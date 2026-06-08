using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class v114 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pagamentos_Pedidos_PedidosID",
                table: "Pagamentos");

            migrationBuilder.AlterColumn<int>(
                name: "PedidosID",
                table: "Pagamentos",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

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
                name: "FK_Pagamentos_Pedidos_PedidosID",
                table: "Pagamentos");

            migrationBuilder.AlterColumn<int>(
                name: "PedidosID",
                table: "Pagamentos",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pagamentos_Pedidos_PedidosID",
                table: "Pagamentos",
                column: "PedidosID",
                principalTable: "Pedidos",
                principalColumn: "PedidosID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
