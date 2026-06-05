namespace backend.Models
{
    public class Cliente
    {
        public int ClienteID {get; set;}
        public string Nome {get; set;} = null!;
        public string? Telefone {get; set;}
        public string? Email {get; set;}

        public List<Pedido> Pedido {get; set;} = [];
    }
}