using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class Alteracaomig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("ALTER TABLE public.\"Pedidos\" ALTER COLUMN \"ClientesID\" DROP DEFAULT;");

            // 2. Permite que a coluna aceite valores nulos (NULL)
            migrationBuilder.Sql("ALTER TABLE public.\"Pedidos\" ALTER COLUMN \"ClientesID\" DROP NOT NULL;");

            // 3. Se houver alguma linha perdida com valor 0, transforma em NULL
            migrationBuilder.Sql("UPDATE public.\"Pedidos\" SET \"ClientesID\" = NULL WHERE \"ClientesID\" = 0;");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
