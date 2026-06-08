namespace backend.Models
{
    public class Pedidos
    {
        public int PedidosID { get; set; }
        public DateTime DataPedido {get; set;}
        public string StatusPedido {get; set;} = "Pendente";
        public string TipoPedido {get; set;} = "Balcão";
        public int ValorTotal {get; set;}


        public int ClientesID { get; set; }
        public Clientes Clientes {get; set; } = null!;

        // public int? MesaID { get; set; }
        public Mesa? Mesa {get; set; } = null!;

        public List<PedidosItensMenu> PedidosItensMenus {get; set;} = [];
        public Endereco? Endereco {get; set; }
        public Pagamentos Pagamentos {get; set;} = null!;
    

    }
}