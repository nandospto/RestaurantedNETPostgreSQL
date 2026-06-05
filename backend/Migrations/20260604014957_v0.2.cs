using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class v02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Mesas_MesasMesaId",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "MesaId",
                table: "Pedidos");

            migrationBuilder.RenameColumn(
                name: "MesasMesaId",
                table: "Pedidos",
                newName: "MesasId");

            migrationBuilder.RenameIndex(
                name: "IX_Pedidos_MesasMesaId",
                table: "Pedidos",
                newName: "IX_Pedidos_MesasId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Mesas_MesasId",
                table: "Pedidos",
                column: "MesasId",
                principalTable: "Mesas",
                principalColumn: "MesaId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Mesas_MesasId",
                table: "Pedidos");

            migrationBuilder.RenameColumn(
                name: "MesasId",
                table: "Pedidos",
                newName: "MesasMesaId");

            migrationBuilder.RenameIndex(
                name: "IX_Pedidos_MesasId",
                table: "Pedidos",
                newName: "IX_Pedidos_MesasMesaId");

            migrationBuilder.AddColumn<int>(
                name: "MesaId",
                table: "Pedidos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Mesas_MesasMesaId",
                table: "Pedidos",
                column: "MesasMesaId",
                principalTable: "Mesas",
                principalColumn: "MesaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
