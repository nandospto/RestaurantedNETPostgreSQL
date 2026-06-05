using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class v08 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Mesas_MesasId",
                table: "Pedidos");

            migrationBuilder.DropTable(
                name: "Mesas");

            migrationBuilder.RenameColumn(
                name: "MesasId",
                table: "Pedidos",
                newName: "MesaId");

            migrationBuilder.RenameIndex(
                name: "IX_Pedidos_MesasId",
                table: "Pedidos",
                newName: "IX_Pedidos_MesaId");

            migrationBuilder.CreateTable(
                name: "Mesa",
                columns: table => new
                {
                    MesaId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Capacidade = table.Column<int>(type: "integer", nullable: false),
                    Disponibilidade = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mesa", x => x.MesaId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Mesa_MesaId",
                table: "Pedidos",
                column: "MesaId",
                principalTable: "Mesa",
                principalColumn: "MesaId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Mesa_MesaId",
                table: "Pedidos");

            migrationBuilder.DropTable(
                name: "Mesa");

            migrationBuilder.RenameColumn(
                name: "MesaId",
                table: "Pedidos",
                newName: "MesasId");

            migrationBuilder.RenameIndex(
                name: "IX_Pedidos_MesaId",
                table: "Pedidos",
                newName: "IX_Pedidos_MesasId");

            migrationBuilder.CreateTable(
                name: "Mesas",
                columns: table => new
                {
                    MesaId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Capacidade = table.Column<int>(type: "integer", nullable: false),
                    Disponibilidade = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mesas", x => x.MesaId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Mesas_MesasId",
                table: "Pedidos",
                column: "MesasId",
                principalTable: "Mesas",
                principalColumn: "MesaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
