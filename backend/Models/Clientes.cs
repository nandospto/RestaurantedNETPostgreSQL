using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Clientes
    {
        [Key]
        public int ClienteId {get; set;}
        public string Nome {get; set;} = null!;
        public string? Email {get; set;}
        public string? Telefone {get; set;}

        public List<Pedidos> Pedidos {get; set;} = new List<Pedidos>();
    }
}