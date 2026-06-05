namespace backend.Dtos
{
    public class PedidoResponseDto
    {
        public int PedidoID { get; set; }
        public string? Descricao { get; set; }
        public DateTime Datapedido { get; set; }
        public bool Status { get; set; }
        public int ClienteID { get; set; }
        public string? ClienteNome {get; set;}
        public int MesaID { get; set; }
    }
}