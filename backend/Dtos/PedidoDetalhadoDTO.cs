using backend.Dtos;

namespace backend.Dtos
{
    public class PedidoDetalhadoDTO
    {
        public int PedidosID { get; set; }
        public DateTime DataPedido {get; set;}
        public string StatusPedido {get; set;} = "Pendente";
        public string TipoPedido {get; set;} = "Balcão";
        public int ValorTotal {get; set;}


        public string? ClienteNome {get; set;}
        public string? ClienteTelefone {get; set;}
        public string? Endereco {get; set;}

        public bool? MesaStatus {get; set;}
        public int? MesaID  {get; set;}

        public List<ItemPedidoDTO> PedidosItensMenus {get; set;} = [];


    }
}