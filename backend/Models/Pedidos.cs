using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class Pedidos
    {
        [Key]
        public int PedidoId {get; set;}
        public string? Descricao {get; set;}

        [ForeignKey(nameof(ClienteId))]
        public int ClienteId {get; set;}
        public Clientes Clientes {get; set;} = null!;
    }
}