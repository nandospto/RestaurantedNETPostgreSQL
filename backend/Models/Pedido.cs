namespace backend.Models
{
    public class Pedido
    {
        public int PedidoID {get; set;}
        public string? Descricao {get; set;}
        public DateTime Datapedido {get; set;}
        public bool Status {get; set;} = false;

        public int ClienteID {get; set;}
        public Cliente Cliente {get; set;} = null!;

        public int MesaID {get; set;}
        public Mesa Mesa {get; set;} = null!;

        public List<PedidosItensMenu> PedidosItensMenus { get; set; } = new List<PedidosItensMenu>();
    
    }
}