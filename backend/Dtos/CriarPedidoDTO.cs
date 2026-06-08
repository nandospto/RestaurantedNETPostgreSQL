using backend.Models;

namespace backend.Dtos
{
    public class CriarPedidoDTO
    {
        public int? ClientesID { get; set; }
        public string? ClienteNome { get; set; }
        public string? ClienteTelefone { get; set; }
        public int? MesaID { get; set; }
        public string TipoPedido { get; set; } = "Balcão";
        public List<ItemPedidoInputDTO> PedidosItensMenu { get; set; } = [];
    }
}