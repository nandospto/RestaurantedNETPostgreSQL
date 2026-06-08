using backend.Models;

namespace backend.Dtos
{
    public class CriarClienteDTO
    {
        public string? Nome {get; set;} = null!;
        public string? Telefone {get; set;}
        public string? Email {get; set;}

        public ICollection<Pedidos> Pedidos {get; set;} = new List<Pedidos>();
    }
}