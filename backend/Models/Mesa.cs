namespace backend.Models
{
    public class Mesa
    {
        public int MesaID {get; set;}
        public int Capacidade {get; set;}
        public bool Disponibilidade {get; set;} = true;

        public List<Pedido> Pedido {get; set;} = [];
        
    }
}