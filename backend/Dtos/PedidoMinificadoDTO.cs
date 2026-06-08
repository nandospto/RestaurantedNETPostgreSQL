namespace backend.Dtos
{
    public class PedidoMinificadoDTO
    {
        public int PedidosID { get; set; }
        public string? ClienteNome {get; set;}
        public DateTime DataPedido {get; set;}
        public string StatusPedido {get; set;} = null!;
        public string TipoPedido {get; set;} = null!;
        public int ValorTotal {get; set;}
    }
}