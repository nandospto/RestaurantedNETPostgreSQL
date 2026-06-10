namespace backend.Dtos.ItensMenu
{
    public class ItensMenuDTO
    {
        public int ItensMenuID {get; set;}
        public string Nome {get; set;} = null!;
        public string? Descricao {get; set;}
        public int Preco {get; set;}
    }
}