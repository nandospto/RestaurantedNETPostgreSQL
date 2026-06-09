namespace backend.Dtos.Pedidos
{
    public class PedidoDetalhadoDTO
    {
        public int PedidosID { get; set; }
        public DateTime DataPedido { get; set; }
        public string StatusPedido { get; set; } = "Pendente";
        public string TipoPedido { get; set; } = "Balcão";
        public int ValorTotal { get; set; }

        public string ClienteNome { get; set; } = "Anônimo";
        public string ClienteTelefone { get; set; } = "Telefone não informado";
        public string Endereco { get; set; } = "Endereço não informado";

        public int? MesaID { get; set; }

        public List<ItemPedidoDTO> PedidosItensMenus { get; set; } = [];
    }
}