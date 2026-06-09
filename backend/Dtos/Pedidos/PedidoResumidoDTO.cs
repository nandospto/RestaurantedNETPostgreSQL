namespace backend.Dtos.Pedidos
{
    public class PedidoResumidoDTO
    {
        public int PedidosID { get; set; }
        public string? ClienteNome { get; set; } = "Anônimo";

        public DateTime DataPedido { get; set; }

        public string StatusPedido { get; set; } = "Pendente";

        public string TipoPedido { get; set; } = "Balcão";
        public int ValorTotal { get; set; } = 0;
    }
}