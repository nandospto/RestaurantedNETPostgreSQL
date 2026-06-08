namespace backend.Models
{
    public class Pagamentos
    {
        public int PagamentosID {get; set;}
        public string PagamentoMetodo {get; set;} = null!;
        public DateTime PagamentoData {get; set;}

        public int PedidosID {get; set;}
        public Pedidos Pedidos {get; set;} = null!;
    }
}