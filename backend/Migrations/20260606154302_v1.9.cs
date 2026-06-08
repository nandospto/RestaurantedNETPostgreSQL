using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class v19 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClientesID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Telefone = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClientesID);
                });

            migrationBuilder.CreateTable(
                name: "ItensMenu",
                columns: table => new
                {
                    ItensMenuID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: true),
                    Preco = table.Column<int>(type: "integer", nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensMenu", x => x.ItensMenuID);
                });

            migrationBuilder.CreateTable(
                name: "Mesa",
                columns: table => new
                {
                    MesaID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Capacidade = table.Column<int>(type: "integer", nullable: false),
                    Disponibilidade = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mesa", x => x.MesaID);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    PedidosID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClientesID = table.Column<int>(type: "integer", nullable: true),
                    MesaID = table.Column<int>(type: "integer", nullable: true),
                    DataPedido = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    StatusPedido = table.Column<string>(type: "text", nullable: false),
                    TipoPedido = table.Column<string>(type: "text", nullable: false),
                    ValorTotal = table.Column<int>(type: "integer", nullable: false),
                    ClientesID1 = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.PedidosID);
                    table.ForeignKey(
                        name: "FK_Pedidos_Clientes_ClientesID",
                        column: x => x.ClientesID,
                        principalTable: "Clientes",
                        principalColumn: "ClientesID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Pedidos_Clientes_ClientesID1",
                        column: x => x.ClientesID1,
                        principalTable: "Clientes",
                        principalColumn: "ClientesID");
                    table.ForeignKey(
                        name: "FK_Pedidos_Mesa_MesaID",
                        column: x => x.MesaID,
                        principalTable: "Mesa",
                        principalColumn: "MesaID");
                });

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    EnderecoID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Logradouro = table.Column<string>(type: "text", nullable: false),
                    Numero = table.Column<string>(type: "text", nullable: false),
                    Complemento = table.Column<string>(type: "text", nullable: true),
                    Bairro = table.Column<string>(type: "text", nullable: false),
                    Cidade = table.Column<string>(type: "text", nullable: false),
                    CEP = table.Column<string>(type: "text", nullable: false),
                    PedidosID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.EnderecoID);
                    table.ForeignKey(
                        name: "FK_Endereco_Pedidos_PedidosID",
                        column: x => x.PedidosID,
                        principalTable: "Pedidos",
                        principalColumn: "PedidosID");
                });

            migrationBuilder.CreateTable(
                name: "Pagamentos",
                columns: table => new
                {
                    PagamentosID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PagamentoMetodo = table.Column<string>(type: "text", nullable: false),
                    PagamentoData = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PedidosID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamentos", x => x.PagamentosID);
                    table.ForeignKey(
                        name: "FK_Pagamentos_Pedidos_PedidosID",
                        column: x => x.PedidosID,
                        principalTable: "Pedidos",
                        principalColumn: "PedidosID");
                });

            migrationBuilder.CreateTable(
                name: "PedidosItensMenu",
                columns: table => new
                {
                    PedidoID = table.Column<int>(type: "integer", nullable: false),
                    ItensMenuID = table.Column<int>(type: "integer", nullable: false),
                    Quantidade = table.Column<int>(type: "integer", nullable: false),
                    PrecoUnit = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidosItensMenu", x => new { x.PedidoID, x.ItensMenuID });
                    table.ForeignKey(
                        name: "FK_PedidosItensMenu_ItensMenu_ItensMenuID",
                        column: x => x.ItensMenuID,
                        principalTable: "ItensMenu",
                        principalColumn: "ItensMenuID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PedidosItensMenu_Pedidos_PedidoID",
                        column: x => x.PedidoID,
                        principalTable: "Pedidos",
                        principalColumn: "PedidosID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_PedidosID",
                table: "Endereco",
                column: "PedidosID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pagamentos_PedidosID",
                table: "Pagamentos",
                column: "PedidosID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ClientesID",
                table: "Pedidos",
                column: "ClientesID");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ClientesID1",
                table: "Pedidos",
                column: "ClientesID1");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_MesaID",
                table: "Pedidos",
                column: "MesaID");

            migrationBuilder.CreateIndex(
                name: "IX_PedidosItensMenu_ItensMenuID",
                table: "PedidosItensMenu",
                column: "ItensMenuID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropTable(
                name: "Pagamentos");

            migrationBuilder.DropTable(
                name: "PedidosItensMenu");

            migrationBuilder.DropTable(
                name: "ItensMenu");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Mesa");
        }
    }
}
