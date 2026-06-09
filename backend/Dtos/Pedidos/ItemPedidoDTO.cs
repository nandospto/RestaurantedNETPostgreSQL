using backend.Dtos;

namespace backend.Dtos.Pedidos
{
    public class ItemPedidoDTO
    {
        public string NomeItem { get; set; } = null!;
        public int Quantidade { get; set; }
        public int Precounit { get; set; }
        public int SubTotal => Quantidade * Precounit;

    }

    public class ItemPedidoInputDTO
    {
        public int ItensMenuID { get; set; }
        public int Quantidade { get; set; }
    }
}