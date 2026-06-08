using System.Collections.Generic;

namespace backend.Models
{
    public class Clientes
    {
        public int ClientesID {get; set;}
        public string Nome {get; set;} = null!;
        public string? Telefone {get; set;}
        public string? Email {get; set;}
        public bool Ativo {get; set;} = true;

        public ICollection<Pedidos> Pedidos {get; set;} = new List<Pedidos>();
    }
}