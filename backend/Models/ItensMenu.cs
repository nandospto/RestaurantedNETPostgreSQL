namespace backend.Models
{
    public class ItensMenu
    {
        public int ItensMenuID {get; set;}
        public string Nome {get; set;} = null!;
        public string? Descricao {get; set;}
        public int Preco {get; set;}

        public List<PedidosItensMenu> PedidosItensMenus {get; set;} = [];

    }
}